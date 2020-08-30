#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the arrayManipulation function below.


def arrayManipulation(n, queries):
    arr = [0]*n
    for query in queries:
        arr[query[0] - 1] += query[2]
        arr[query[1] - 1] -= query[2]
    return sum(arr)


def arrayManipulationNaive2(n, queries):
    arr = [0]*n
    for query in queries:
        for i in range(query[0] - 1, query[1]):
            arr[i] += query[2]
    return max(arr)


def arrayManipulationNaive1(n, queries):
    # O(n*m) implementation
    maxValue = 0
    for i in range(1, n+1):
        localMax = 0
        for query in queries:
            if(i >= query[0] and i <= query[1]):
                localMax += query[2]
        if(localMax > maxValue):
            maxValue = localMax
    return maxValue


if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    nm = input().split()

    n = int(nm[0])

    m = int(nm[1])

    queries = []

    for _ in range(m):
        queries.append(list(map(int, input().rstrip().split())))

    result = arrayManipulation(n, queries)

    fptr.write(str(result) + '\n')

    fptr.close()
