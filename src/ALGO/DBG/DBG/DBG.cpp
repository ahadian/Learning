/*
Problem Name:
Problem Link:
Algorithm:
Solution Author:
Date:
*/
#define CLOCKS_PER_SEC 1000
#include "stdafx.h"

#include <cctype>
#include <cerrno>
#include <cfloat>
#include <ciso646>
#include <climits>
#include <clocale>
#include <cmath>
#include <csetjmp>
#include <csignal>
#include <cstdarg>
#include <cstddef>
#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <ctime>


// C++
#include <algorithm>
#include <bitset>
#include <complex>
#include <deque>
#include <exception>
#include <fstream>
#include <functional>
#include <iomanip>
#include <ios>
#include <iosfwd>
#include <iostream>
#include <istream>
#include <iterator>
#include <limits>
#include <list>
#include <locale>
#include <map>
#include <memory>
#include <new>
#include <numeric>
#include <ostream>
#include <queue>
#include <set>
#include <sstream>
#include <stack>
#include <stdexcept>
#include <streambuf>
#include <string>
#include <typeinfo>
#include <utility>
#include <valarray>
#include <vector>

using namespace std;
/***************************************************************************************************************************************/
typedef long long int LLI;
typedef unsigned long long int ULLI;
#define MP(X,Y)         make_pair(X,Y)
#define fill(a,v)       memset(a,v,sizeof(a))
#define DEBUG(x)        cout << #x << ": " << x << endl;
#define all(x)          (x).begin(),(x).end()
#define SORT(x)         sort(all(x))
#define VI              vector<int>
#define SI              set<int>
#define VS              vector<string>
#define PB              push_back
#define REV(a)          reverse(all(a))
#define BRPS(n,bit)     bitset<bit>(n)
#define LB(A, x)        (lower_bound(all(A), x) - A.begin())//exactly where it starts
#define UB(A, x)        (upper_bound(all(A), x) - A.begin())
#define UNQ(x)          SORT(x),(x).erase(unique(all(x)),x.end())
#define FOR(i,a,b)      for(int i=(int)(a);i<=(int)(b);i++)
#define foreach(e,x)    for(__typeof(x.begin()) e=x.begin();e!=x.end();++e)
#define DBG(v)          std::copy( v.begin(), v.end(), std::ostream_iterator < typeof( *v.begin() )> ( std::cout, " " ) )
#define INF             0x7FFFFFFF
#define INFL            0x7FFFFFFFFFFFFFFF

typedef pair<int, int>PII;
typedef pair<LLI, LLI>PLL;

template<class T> inline T BIGMOD(T n, T m, T mod)
{
	LLI ans = 1;
	LLI k = n;
	while (m)
	{
		if (m & 1)
		{
			ans *= k;
			if (ans > mod) ans %= mod;
		}
		k *= k;
		if (k > mod) k %= mod;
		m >>= 1;
	}
	return ans;
}
#define eps 1e-11
template<class T> string toString(T n)
{
	ostringstream ost;
	ost << n;
	ost.flush();
	return ost.str();
}
template<class T> string toBinary(T n)
{
	string ret = "";
	while (n)
	{
		if (n % 2 == 1)ret += '1';
		else ret += '0';
		n >>= 1;
	}
	reverse(ret.begin(), ret.end());
	return ret;
}
void combination(int n, vector< vector<int> > &ret)
{
	ret.resize(n + 1, vector<int>(n + 1, 0));
	for (int i = 1; i <= n; i++)
	{
		ret[i][0] = ret[i][i] = 1;
		for (int j = 1; j < i; j++)
		{
			ret[i][j] = ret[i - 1][j] + ret[i - 1][j - 1];
		}
	}
}
int toInt(string s)
{
	int r = 0;
	istringstream sin(s);
	sin >> r;
	return r;
}
LLI toLInt(string s)
{
	LLI r = 0;
	istringstream sin(s);
	sin >> r;
	return r;
}
vector<string> parse(string temp)
{
	vector<string> ans;
	ans.clear();
	string s;
	istringstream iss(temp);
	while (iss >> s)ans.PB(s);
	return ans;
}
template<class T> inline T gcd(T a, T b)
{
	if (a < 0)return gcd(-a, b);
	if (b < 0)return gcd(a, -b);
	return (b == 0) ? a : gcd(b, a % b);
}
template<class T> inline T lcm(T a, T b)
{
	if (a < 0)return lcm(-a, b);
	if (b < 0)return lcm(a, -b);
	return a*(b / gcd(a, b));
}
template<class T> inline T power(T b, T p)
{
	if (p < 0)return -1;
	if (b <= 0)return -2;
	if (!p)return 1;
	return b*power(b, p - 1);
}

template<class T> inline int asd(T &ret)
{
	char r;
	bool start = false, neg = false;
	ret = 0;
	bool isaNumber = false;
	while (true)
	{
		r = getchar();
		if (r == EOF)
		{
			return 0;
		}
		if ((r - '0' < 0 || r - '0'>9) && r != '-' && !start)
		{
			continue;
		}
		if ((r - '0' < 0 || r - '0'>9) && r != '-' && start)
		{
			break;
		}
		if (start)ret *= 10;
		start = true;
		if (r == '-')neg = true;
		else ret += r - '0';
	}
	if (neg)
		ret *= -1;
	return 1;
}

// Yet to Test
template<class T> inline int asd(T &ret1, T &ret2)
{
	asd(ret1);
	asd(ret2);
	return 2;
}
template<class T> inline int asd(T &ret1, T &ret2, T &ret3)
{
	asd(ret1, ret2);
	asd(ret3);
	return 3;
}
template<class T> inline int asd(T &ret1, T &ret2, T &ret3, T &ret4)
{
	asd(ret1, ret2);
	asd(ret3, ret4);
	return 4;
}

template<class T> inline void asdasd(T x, char endWith)
{
	if (x < 0)
	{
		putchar('-');
		x = -x;
	}
	char buf[21], *p = buf;
	do
	{
		*p++ = '0' + x % 10;
		x /= 10;
	} while (x);
	do
	{
		putchar(*--p);
	} while (p > buf);
	putchar(endWith);
}

template<class T> inline void asdasd(T x1, T x2, char separateBy, char endWith)
{
	asdasd(x1, separateBy);
	asdasd(x2, endWith);
}

template<class T> inline void asdasd(T x1, T x2, T x3, char separateBy, char endWith)
{
	asdasd(x1, x2, separateBy, separateBy);
	asdasd(x3, endWith);
}
template<class T> inline void asdasd(T x1, T x2, T x3, T x4, char separateBy, char endWith)
{
	asdasd(x1, x2, x3, separateBy, separateBy);
	asdasd(x4, endWith);
}


/*vector IO*/
template < typename value_type >
istream & operator>> (istream & in, vector < value_type > & a)
{
	typedef typename vector < value_type >::iterator iterator;
	if (!a.size())
	{
		size_t n;
		asd(n);
		a.resize(n);
	}
	for (iterator iter = a.begin(); iter != a.end(); ++iter)
		asd(*iter);
	return in;
}

//vector1D OUT
template < typename value_type >
ostream & operator<< (ostream & out, const vector <  value_type > & a)
{
	int sz = a.size();
	FOR(i, 0, sz - 1)asdasd(a[i], i != sz);
	return out;
}

//vector2D OUT
template < typename value_type >
ostream & operator<< (ostream & out, const vector < vector< value_type > > & a)
{
	int sza = a.size();
	int szb = a[0].size();
	FOR(i, 0, sza - 1)
	{
		FOR(j, 0, szb - 1)asdasd(a[i][j], j != sza);
		puts("");
	}
	return out;
}
//set OUT
template < typename value_type >
ostream & operator<< (ostream & out, const set <  value_type > & a)
{
	foreach(e, a)asdasd(*e, e != a.end());
	return out;
}
//MAP OUT
template < typename key_type, typename value_type >
ostream & operator<< (ostream & in, map < key_type, value_type > & a)
{
	foreach(e, a)
	{
		cout << (*e).first << " -> " << (*e).second << endl;
	}
	return in;
}
/*END OF STL IO*/
template < typename key_type, typename value_type >
istream & operator>> (istream & in, pair < key_type, value_type > & p)
{
	in >> p.first >> p.second;
	return in;
}
template < typename key_type, typename value_type >
ostream & operator<< (ostream & out, const pair < key_type, value_type > & p)
{
	out << "(" << p.first << ", " << p.second << ")";
	return out;
}
vector<int> inverseArray(int n, int m)
{
	vector<int> modI(n + 1, 0);
	modI[1] = 1;
	for (int i = 2; i <= n; i++)
	{
		modI[i] = (-(m / i) * modI[m % i]) % m + m;
	}
	return modI;
}

pair<LLI, pair<LLI, LLI> > extendedEuclid(LLI a, LLI b)
{
	LLI x = 1, y = 0;
	LLI xLast = 0, yLast = 1;
	LLI q, r, m, n;
	while (a != 0)
	{
		q = b / a;
		r = b % a;
		m = xLast - q * x;
		n = yLast - q * y;
		xLast = x, yLast = y;
		x = m, y = n;
		b = a, a = r;
	}
	return make_pair(b, make_pair(xLast, yLast));
}

LLI modInverse(LLI a, LLI m)
{
	return (extendedEuclid(a, m).second.first + m) % m;
}

#define printCaseSpace(caseNo) printf("Case %d: ",caseNo);
#define printCaseNewLine(caseNo) printf("Case %d:\n",caseNo);

#define filein(x) freopen(x,"r",stdin)
#define fileout(x) freopen(x,"w",stdout)
#define fst first
#define snd second
//istringstream(temp) >> data >> value >> stamp;
//mod1 = 1000000007, mod2 = 1000000009;
//.016-.040-.900-2.48
/***************************************************************************************************************************************/
//#include <bits/stdc++.h>
using namespace std;
typedef long long int LLI;
#define MP(X,Y)         make_pair(X,Y)
#define fill(a,v)       memset(a,v,sizeof(a))
#define all(x)          (x).begin(),(x).end()
#define VI              vector<int>
#define VS              vector<string>
#define PB              push_back
#define REV(a)          reverse(all(a))
#define BRPS(n,bit)     bitset<bit>(n)
#define FOR(i,a,b)      for(int i=(int)(a);i<=(int)(b);i++)
typedef pair<int, int>PII;
typedef pair<LLI, LLI>PLL;
#define fst first
#define snd second
using namespace std;


int target;
int flood[1001][1001][1001 >> 5];

int get(int a, int b, int c)
{
	return flood[a][b][c / 32] & (1 << (c % 32));
}

int Set(int a, int b, int c)
{
	return flood[a][b][c / 32] |= (1 << (c % 32));
}


int mini(int a, int b, int c)
{
	int arr[3];
	arr[0] = a;
	arr[1] = b;
	arr[2] = c;
	sort(arr, arr + 3);
	return arr[0];
}
int mini2(int a, int b, int c)
{
	int arr[3];
	arr[0] = a;
	arr[1] = b;
	arr[2] = c;
	sort(arr, arr + 3);
	return arr[1];
}
int mini3(int a, int b, int c)
{
	int arr[3];
	arr[0] = a;
	arr[1] = b;
	arr[2] = c;
	sort(arr, arr + 3);
	return arr[2];
}

bool ok(int m0, int m1, int m2)
{
	if (m0 < 0 || m0>1000)return false;
	if (m1 < 0 || m1>1000)return false;
	if (m2 < 0 || m2>1000)return false;
	return true;

}
bool found;
int rec(int a, int b, int c)
{
	if (a < 0 || b < 0 || c < 0 || a>1000 || b>1000 || c>1000)return 0;
	Set(a, b, c);
	if (a == target && b == target && c == target){
		found = true;
	}
	
	if (!found)
	{
		/*ret |= rec(mini(a + a, b - a, c), mini2(a + a, b - a, c), mini3(a + a, b - a, c));*/
		int m0 = mini(a + a, b - a, c), m1 = mini2(a + a, b - a, c), m2 = mini3(a + a, b - a, c);
		if (ok(m0, m1, m2) && !get(m0,m1,m2) && a < b)
			rec(m0, m1, m2);

		m0 = mini(a + a, b, c - a), m1 = mini2(a + a, b, c - a), m2 = mini3(a + a, b, c - a);

		if (ok(m0, m1, m2) && !get(m0, m1, m2) && a < c)
			rec(m0, m1, m2);

		m0 = mini(a, b + b, c - b), m1 = mini2(a, b + b, c - b), m2 = mini3(a, b + b, c - b);
		if (ok(m0, m1, m2) && !get(m0, m1, m2) && b < c)
			rec(m0, m1, m2);
	}
}

class BearPlaysDiv2
{
public:
	string equalPiles(int A, int B, int C)
	{
		target = A + B + C;
		if (target % 3)return "impossible";
		target /= 3;
		fill(flood, 0);
		found = false;
		int dbg = rec(A, B, C);
		if (found)
		{
			return "possible";
		}
		return "impossible";
		
	}
};


// BEGIN KAWIGIEDIT TESTING
// Generated by KawigiEdit-pf 2.3.0
#include <iostream>
#include <string>
#include <vector>
#include <ctime>
#include <cmath>
using namespace std;
bool KawigiEdit_RunTest(int testNum, int p0, int p1, int p2, bool hasAnswer, string p3)
{
	cout << "Test " << testNum << ": [" << p0 << "," << p1 << "," << p2;
	cout << "]" << endl;
	BearPlaysDiv2 *obj;
	string answer;
	obj = new BearPlaysDiv2();
	clock_t startTime = clock();
	answer = obj->equalPiles(p0, p1, p2);
	clock_t endTime = clock();
	delete obj;
	bool res;
	res = true;
	cout << "Time: " << double(endTime - startTime) / CLOCKS_PER_SEC << " seconds" << endl;
	if (hasAnswer)
	{
		cout << "Desired answer:" << endl;
		cout << "\t" << "\"" << p3 << "\"" << endl;
	}
	cout << "Your answer:" << endl;
	cout << "\t" << "\"" << answer << "\"" << endl;
	if (hasAnswer)
	{
		res = answer == p3;
	}
	if (!res)
	{
		cout << "DOESN'T MATCH!!!!" << endl;
	}
	else if (double(endTime - startTime) / CLOCKS_PER_SEC >= 2)
	{
		cout << "FAIL the timeout" << endl;
		res = false;
	}
	else if (hasAnswer)
	{
		cout << "Match :-)" << endl;
	}
	else
	{
		cout << "OK, but is it right?" << endl;
	}
	cout << "" << endl;
	return res;
}
int main()
{
	bool all_right;
	bool disabled;
	bool tests_disabled;
	all_right = true;
	tests_disabled = false;

	int p0;
	int p1;
	int p2;
	string p3;

	//// ----- test 0 -----
	//disabled = false;
	//p0 = 10;
	//p1 = 15;
	//p2 = 35;
	//p3 = "possible";
	//all_right = (disabled || KawigiEdit_RunTest(0, p0, p1, p2, true, p3)) && all_right;
	//tests_disabled = tests_disabled || disabled;
	//// ------------------

	//// ----- test 1 -----
	//disabled = false;
	//p0 = 1;
	//p1 = 1;
	//p2 = 2;
	//p3 = "impossible";
	//all_right = (disabled || KawigiEdit_RunTest(1, p0, p1, p2, true, p3)) && all_right;
	//tests_disabled = tests_disabled || disabled;
	//// ------------------

	//// ----- test 2 -----
	//disabled = false;
	//p0 = 4;
	//p1 = 6;
	//p2 = 8;
	//p3 = "impossible";
	//all_right = (disabled || KawigiEdit_RunTest(2, p0, p1, p2, true, p3)) && all_right;
	//tests_disabled = tests_disabled || disabled;
	//// ------------------

	//// ----- test 3 -----
	//disabled = false;
	//p0 = 18;
	//p1 = 18;
	//p2 = 18;
	//p3 = "possible";
	//all_right = (disabled || KawigiEdit_RunTest(3, p0, p1, p2, true, p3)) && all_right;
	//tests_disabled = tests_disabled || disabled;
	//// ------------------

	// ----- test 4 -----
	disabled = false;
	p0 = 225;
	p1 = 500;
	p2 = 475;
	p3 = "possible";
	all_right = (disabled || KawigiEdit_RunTest(4, p0, p1, p2, true, p3)) && all_right;
	tests_disabled = tests_disabled || disabled;
	// ------------------

	if (all_right)
	{
		if (tests_disabled)
		{
			cout << "You're a stud (but some test cases were disabled)!" << endl;
		}
		else
		{
			cout << "You're a stud (at least on given cases)!" << endl;
		}
	}
	else
	{
		cout << "Some of the test cases had errors." << endl;
	}
	getchar();
	return 0;
}
// PROBLEM STATEMENT
// Limak is a little bear who loves to play.
// Today he is playing by moving some stones between three piles of stones.
// Initially, the piles contain A, B, and C stones, respectively.
// Limak's goal is to produce three equal piles.
//
// Limak will try reaching his goal by performing a sequence of zero or more operations.
// In each operation he will start by choosing two unequal piles.
// Let's label their sizes X and Y in such a way that X < Y.
// He will then double the size of the smaller chosen pile by moving some stones between the two chosen piles.
// Formally, the new sizes of the two chosen piles will be X+X and Y-X.
//
// You are given the ints A, B, and C.
// Return "possible" (quotes for clarity) if there is a sequence of operations that will make all three piles equal.
// Otherwise, return "impossible".
//
// DEFINITION
// Class:BearPlaysDiv2
// Method:equalPiles
// Parameters:int, int, int
// Returns:string
// Method signature:string equalPiles(int A, int B, int C)
//
//
// CONSTRAINTS
// -A, B and C will be between 1 and 500, inclusive.
//
//
// EXAMPLES
//
// 0)
// 10
// 15
// 35
//
// Returns: "possible"
//
// One valid sequence of operations looks as follows:
//
// The initial pile sizes are 10, 15, and 35.
// For the first operation Limak will choose the piles with 15 and 35 stones. After doubling the size of the smaller pile the new sizes of these two piles will be 30 and 20.
// After the first operation the pile sizes are 10, 30, and 20.
// For the second operation Limak will choose the piles with 10 and 30 stones. After doubling the size of the smaller pile the new sizes of these two piles will be 20 and 20.
// After the second operation each pile has 20 stones, which means that Limak has reached his goal.
//
//
// 1)
// 1
// 1
// 2
//
// Returns: "impossible"
//
// No matter what Limak does, there will always be two piles with a single stone each and one pile with 2 stones.
//
// 2)
// 4
// 6
// 8
//
// Returns: "impossible"
//
//
//
// 3)
// 18
// 18
// 18
//
// Returns: "possible"
//
// Sometimes Limak can reach his goal without making any operations.
//
// 4)
// 225
// 500
// 475
//
// Returns: "possible"
//
//
//
// END KAWIGIEDIT TESTING
//Powered by KawigiEdit-pf 2.3.0!

