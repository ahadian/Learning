// Thesis.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>
#include "myGA.h" 
#include "mypgm.h"

#define MIN_RATE      1.0   
#define MAX_RATE      3.0   
#define ANGLE_RANGE  60.0   
#define MIN_MATCHING_RATE 0.90 
#define MAX_GENERATION    1000 
#define MIN_RANGE   50  
#define PI  3.141592653589  


/* prototype declaration */
void set_optimizing_task();
void trans_from_genotype_to_parameters(int number, int *x, int *y,
	double *rate, double *angle);
double fitness_value(int number, int flag);
void calculate_fitness();
void display_elitest(int generation);
void generation_iteration();
void move_image1_to_image2();


int main()
{
	char filename[MAX_FILENAME];

	initialize_random_number();
	set_optimizing_task();
	initialize_parameters();
	initialize_genes();
	printf("\n\nEnter Whole image filename : ");
	scanf("%s", filename);
	load_image_file(filename);
	move_image1_to_image2();
	printf("\nEnter Template image filename : ");
	scanf("%s", filename);
	load_image_file(filename);
	printf("\n\nGA starts!\n\n");
	generation_iteration();
	printf("\n\nEnter Extracted result image filename : ");
	scanf("%s", filename);
	save_image_file(filename);
	printf("\n");
}


void set_optimizing_task()
{
	gene_size = 32;
}


void trans_from_genotype_to_parameters(int number, int *x, int *y, double *rate, double *angle)
{
	int i;
	static unsigned char code[MAX_GENE_SIZE];
	for (i = 0; i < gene_size; i++)
		code[i] = genotype[number][i];
	for (i = 0; i < 7; i++) {
		if (code[i] == 1)
			code[i + 1] = (unsigned char)(1 - code[i + 1]);
		if (code[i + 8] == 1)
			code[i + 9] = (unsigned char)(1 - code[i + 9]);
		if (code[i + 16] == 1)
			code[i + 17] = (unsigned char)(1 - code[i + 17]);
		if (code[i + 24] == 1)
			code[i + 25] = (unsigned char)(1 - code[i + 25]);
	}
	*x = 0;
	*y = 0;
	*rate = 0.0;
	*angle = 0.0;
	for (i = 0; i < 8; i++){
		*x = *x * 2 + code[i];
		*y = *y * 2 + code[i + 8];
		*rate = *rate * 2.0 + code[i + 16];
		*angle = *angle * 2.0 + code[i + 24];
	}

	*x = (int)(*x / 255.0 * x_size2);
	*y = (int)(*y / 255.0 * y_size2);
	*rate = (MAX_RATE - MIN_RATE) * *rate / 255.0 + MIN_RATE;
	*angle = ANGLE_RANGE * *angle / 255.0 - ANGLE_RANGE / 2.0;
	if (*angle < 0) *angle = 360.0 + *angle;
}


double fitness_value(int number, int flag)
{
	int x, y;
	int xp, yp, ix2, iy2;
	int x_half, y_half;
	double x1, y1, x2, y2;
	double rate, angle;
	double sum;
	double min_gray, max_gray;
	double _sin, _cos;
	int count;
	double ratio;
	double mean1, mean2, var1, var2;
	int mix;

	trans_from_genotype_to_parameters(number, &xp, &yp, &rate, &angle);
	x_half = x_size1 / 2;
	y_half = y_size1 / 2;
	min_gray = MAX_BRIGHTNESS;
	max_gray = 0;
	_sin = sin(angle * PI / 180.0);
	_cos = cos(angle * PI / 180.0);

	count = 0;
	mean1 = mean2 = 0.0;
	var1 = var2 = 0.0;
	sum = 0.0;
	for (y = 0; y < y_size1; y++) {
		for (x = 0; x < x_size1; x++) {

			x1 = x - x_half;
			y1 = y - y_half;
			x1 = x1 * rate;
			y1 = y1 * rate;
			x2 = _cos * x1 - _sin * y1;
			y2 = _sin * x1 + _cos * y1;
			x2 = x2 + xp;    y2 = y2 + yp;
			ix2 = (int)x2;
			iy2 = (int)y2;

			if (0 <= ix2 && ix2 < x_size2 && 0 <= iy2 && iy2 < y_size2) {
				count++;
				sum += (double)image1[y][x] * image2[iy2][ix2];
				mean1 += (double)image1[y][x];
				mean2 += (double)image2[iy2][ix2];
				var1 += (double)image1[y][x] * image1[y][x];
				var2 += (double)image2[iy2][ix2] * image2[iy2][ix2];
				if (image2[iy2][ix2] > max_gray)
					max_gray = image2[iy2][ix2];
				if (image2[iy2][ix2] < min_gray)
					min_gray = image2[iy2][ix2];
				if (flag == 1) {
					mix = image2[iy2][ix2] / 4 + image1[y][x] * 3 / 4;
					image2[iy2][ix2] = mix > MAX_BRIGHTNESS ? MAX_BRIGHTNESS : mix;
					if (x == 0 || x == x_size1 - 1 || y == 0 || y == y_size1 - 1)
						image2[iy2][ix2] = 0;
				}
			}
		}
	}

	mean1 /= (double)count;
	mean2 /= (double)count;
	var1 = var1 - count*mean1*mean1;
	var2 = var2 - count*mean2*mean2;
	sum = sum - count*mean1*mean2;
	sum /= sqrt(var1)*sqrt(var2);


	if (max_gray - min_gray < MIN_RANGE) sum = 0.1;


	ratio = (double)count / (x_size1*y_size1);
	sum *= ratio;

	return sum;
}


void calculate_fitness()
{
	int i;

	for (i = 0; i < pop_size; i++)
		fitness[i] = fitness_value(i, 0);
}


void display_elitest(int generation)

{
	int i;

	printf("No. %d : ", generation);
	for (i = 0; i < gene_size; i++) {
		printf("%d", elite_genotype[i]);
		if ((i + 1) % 8 == 0) printf(" ");
	}
	printf("--> %f\n", elite_fitness);
}


void generation_iteration()

{
	int generation;
	int x, y;
	double rate, angle, f;

	generation = 0;
	calculate_fitness();
	find_and_set_best_individual();
	do{
		generation++;
		selection_using_roulette_rule();
		execute_crossover();
		execute_mutation();
		calculate_fitness();
		if (elite_flag == 1) elitist_strategy();
		find_and_set_best_individual();
		display_elitest(generation);
	} while (elite_fitness < MIN_MATCHING_RATE &&
		generation < MAX_GENERATION);
	trans_from_genotype_to_parameters(elite_number, &x, &y, &rate, &angle);
	printf("\nfinal solution : (x, y) = (%d, %d), rate = %f, angle = %f\n",
		x, y, rate, angle);
	f = fitness_value(elite_number, 1);
}


void move_image1_to_image2()
{
	int x, y;

	for (y = 0; y < y_size1; y++)
		for (x = 0; x < x_size1; x++)
			image2[y][x] = image1[y][x];
	x_size2 = x_size1;    y_size2 = y_size1;
}
