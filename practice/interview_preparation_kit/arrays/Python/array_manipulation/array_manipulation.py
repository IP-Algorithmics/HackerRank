#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the arrayManipulation function below.


def arrayManipulation(n, queries):
    maxValue = 0
    for i in range(1, n+1):
        localMax = 0
        for querry in queries:
            if(i >= querry[0] and i <= querry[1]):
                localMax += querry[2]
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
