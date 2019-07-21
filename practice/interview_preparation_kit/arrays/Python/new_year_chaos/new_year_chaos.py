#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the minimumBribes function below.


def minimumBribes(q):
    bribes = 0
    for index, item in enumerate(q, start=1):
        if(item - index > 2):
            print("Too chaotic")
            return
        for j in range(max(0, item - 2), index):
            if q[j] > item:
                bribes += 1
    print(bribes)


if __name__ == '__main__':
    t = int(input())

    for t_itr in range(t):
        n = int(input())

        q = list(map(int, input().rstrip().split()))

        minimumBribes(q)
