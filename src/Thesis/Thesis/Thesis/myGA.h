
#define MAX_POP_SIZE   200   
#define MAX_GENE_SIZE   50   

unsigned char genotype[MAX_POP_SIZE][MAX_GENE_SIZE];
unsigned char new_genotype[MAX_POP_SIZE][MAX_GENE_SIZE];


double fitness[MAX_POP_SIZE];
double new_fitness[MAX_POP_SIZE];


unsigned char elite_genotype[MAX_GENE_SIZE];
double elite_fitness;
int elite_number; 


int pop_size;    
int gene_size;   
double crossover_rate;  
double mutation_rate;   
int elite_flag; 
int crs_type;   


void initialize_random_number(); 
int random_int(int n);          
double random_double(double n); 


void swap_unsigned_char(unsigned char *n1, unsigned char *n2);
void swap_int(int *n1, int *n2); 
void intialize_parameters();     
void initialize_genes();         
void copy_new_to_old();          
void one_point_crossover(int n1, int n2); 
void two_point_crossover(int n1, int n2); 
void uniform_crossover(int n1, int n2); 
void selection_using_roulette_rule(); 
void execute_crossover(); 
void execute_mutation();
void find_and_set_best_individual(); 
void elitist_strategy(); 


void initialize_random_number()
{
	time_t now;		

	time(&now);		

	srand(now);	
}


int random_int(int n)
{
	return (int)((double)rand() / ((double)RAND_MAX + 1.0) * n);
}


double random_double(double n)
{
	return (double)rand() / ((double)RAND_MAX + 1.0) * n;
}


void swap_unsigned_char(unsigned char *n1, unsigned char *n2)
{
	unsigned char n;
	n = *n1;
	*n1 = *n2;
	*n2 = n;
}


void swap_int(int *n1, int *n2)
{
	int n;
	n = *n1;
	*n1 = *n2;
	*n2 = n;
}


void initialize_parameters()
{
	float work;

	printf("\n***** Setting of GA parameters *****\n");
	do {
		printf("\nPopulation size (10 - %d) : ", MAX_POP_SIZE);
		scanf("%d", &pop_size);
	} while (pop_size < 10 || pop_size > MAX_POP_SIZE);
	do {
		printf("\nCrossover method (1:1 point  2:2point  3:uniform) : ");
		scanf("%d", &crs_type);
	} while (crs_type != 1 && crs_type != 2 && crs_type != 3);
	do {
		printf("\nRate of crossover (0.0 - 1.0; ex. 0.8) : ");
		scanf("%f", &work);    crossover_rate = work;

	} while (crossover_rate < 0.0 || crossover_rate > 1.0);
	do {
		printf("\nMutation rate (0.0 - 1.0; ex. 0.02) : ");
		scanf("%f", &work);    mutation_rate = work;
	} while (mutation_rate < 0.0 || mutation_rate > 1.0);
	printf("\nKeep elite or not (y = 1, n = 0) : ");
	scanf("%d", &elite_flag);
	if (elite_flag != 1) elite_flag = 0;
}


void initialize_genes()
{
	int i, j;        

	for (i = 0; i < pop_size; i++) {
		for (j = 0; j < gene_size; j++) {
			if (random_double(1.0) < 0.5) genotype[i][j] = 0;
			else genotype[i][j] = 1;
		}
	}
}


void copy_new_to_old()
{
	int i, j;

	for (i = 0; i < pop_size; i++) {
		for (j = 0; j < gene_size; j++)
			genotype[i][j] = new_genotype[i][j];
		fitness[i] = new_fitness[i];
	}
}


void one_point_crossover(int n1, int n2)

{
	int crs_pnt;
	int i;

	crs_pnt = random_int(gene_size);
	for (i = crs_pnt + 1; i < gene_size; i++) {
		swap_unsigned_char(&genotype[n1][i], &genotype[n2][i]);
	}
}


void two_point_crossover(int n1, int n2)
{
	int crs_pnt1, crs_pnt2;  
	int i;               

	crs_pnt1 = random_int(gene_size);
	do {
		crs_pnt2 = random_int(gene_size);
	} while (crs_pnt1 == crs_pnt2);
	if (crs_pnt1 > crs_pnt2) swap_int(&crs_pnt1, &crs_pnt2);
	for (i = crs_pnt1 + 1; i < crs_pnt2; i++) {
		swap_unsigned_char(&genotype[n1][i], &genotype[n2][i]);
	}
}


void uniform_crossover(int n1, int n2)
{
	int i;
	for (i = 0; i < gene_size; i++) {
		if (random_double(1.0) < 0.5) {
			swap_unsigned_char(&genotype[n1][i], &genotype[n2][i]);
		}
	}
}


void selection_using_roulette_rule()
{
	int i, j, num; 
	double sum, rand_real;  
	static double roulette_table[MAX_POP_SIZE]; 
	sum = 0.0;
	for (i = 0; i < pop_size; i++)
		sum = sum + fitness[i];
	for (i = 0; i < pop_size; i++) {
		roulette_table[i] = fitness[i] / sum;
	}
	sum = 0.0;
	for (i = 0; i < pop_size; i++) {
		sum = sum + roulette_table[i];
		roulette_table[i] = sum;
	}
	for (i = 0; i < pop_size; i++) {
		rand_real = random_double(1.0);  
		for (num = 0; num < pop_size; num++) {
			if (roulette_table[num] > rand_real) break;
		}
		for (j = 0; j < gene_size; j++)
			new_genotype[i][j] = genotype[num][j];
		new_fitness[i] = fitness[num];
	}
	copy_new_to_old();
}


void execute_crossover()
{
	int i;  
	int num1, num2; 
	int num_of_pair;   
	static int number[MAX_POP_SIZE]; 

	for (i = 0; i < pop_size; i++) number[i] = i; 
	for (i = 0; i < pop_size * 10; i++) {
		num1 = random_int(pop_size);
		num2 = random_int(pop_size);
		swap_int(&number[num1], &number[num2]);
	}
	num_of_pair = pop_size / 2;
	for (i = 0; i < num_of_pair; i++) {
		num1 = number[2 * i];    
		num2 = number[2 * i + 1]; 
		if (random_double(1.0) <= crossover_rate) {
			if (crs_type == 1) one_point_crossover(num1, num2);
			else if (crs_type == 2) two_point_crossover(num1, num2);
			else uniform_crossover(num1, num2);
		}
	}
}


void execute_mutation()
{
	int i, j;

	for (i = 0; i < pop_size; i++) {
		for (j = 0; j < gene_size; j++) {
			if (random_double(1.0) <= mutation_rate)
				genotype[i][j] = (unsigned char)(1 - genotype[i][j]);
		}
	}
}


void find_and_set_best_individual()
{
	int i; 
	double best_fitness; 

	best_fitness = 0.0;
	for (i = 0; i < pop_size; i++)
		if (fitness[i] > best_fitness) {
			elite_number = i;
			best_fitness = fitness[i];
		}
	for (i = 0; i < gene_size; i++)
		elite_genotype[i] = genotype[elite_number][i];
	elite_fitness = fitness[elite_number];
}


void elitist_strategy()
{
	int worst_number;     
	int i;           
	double worst_fitness; 

	worst_fitness = 1.0;
	worst_number = 0;
	for (i = 0; i < pop_size; i++) {
		if (fitness[i] < worst_fitness) {
			worst_number = i;
			worst_fitness = fitness[i];
		}
	}
	for (i = 0; i < gene_size; i++)
		genotype[worst_number][i] = elite_genotype[i];
	fitness[worst_number] = elite_fitness;
}
