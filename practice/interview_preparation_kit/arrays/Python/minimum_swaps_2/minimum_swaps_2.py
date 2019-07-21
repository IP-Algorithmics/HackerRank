import math
import os
import random
import re
import sys

# Complete the minimumSwaps function below.


def minimumSwaps(arr):
    minCount, i = 0, 0
    while i < len(arr):
        # if the value is not the same as the position then swap the current value with the one from the position we know it should be
        if arr[i] != i+1:
            temp = arr[i]-1
            arr[i], arr[temp] = arr[temp], arr[i]
            i -= 1
            minCount += 1
        i += 1
    return minCount


if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    n = int(input())

    arr = list(map(int, input().rstrip().split()))

    res = minimumSwaps(arr)

    fptr.write(str(res) + '\n')

    fptr.close()
