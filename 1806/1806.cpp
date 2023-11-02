#include <iostream>
#include <vector>
#include <algorithm>
#include <climits>

int main()
{
	int N;
	int S;

	std::cin >> N;
	std::cin >> S;

	std::vector<int> numbers(N);

	for (int i = 0; i < N; i++) {
		std::cin >> numbers[i];
	}

	int sum = 0;
	int start = 0;
	int end = 0;
	int min = INT_MAX;

	while (true)
	{
		if (sum >= S) {
			min = std::min(min, end - start);
			sum -= numbers[start++];
		}
		else if (end < N) {
			sum += numbers[end++];
		}
		else {
			break;
		}
	}

	if (min == INT_MAX) {
		std::cout << 0;
	}
	else {
		std::cout << min;
	}

	return 0;
}