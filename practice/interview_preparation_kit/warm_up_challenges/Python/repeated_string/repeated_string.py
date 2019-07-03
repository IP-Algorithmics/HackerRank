#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the repeatedString function below.
def repeatedString(s, n):
    length = len(s)
    multiple = n // length
    reminder = n % length
    counter = 0
    for i in range (0,length ):
        if(s[i] == 'a'):
            if(i < reminder):
                counter += multiple + 1
            else:
                counter += multiple
    return counter

def repeatedString2(s,n):
    return (s.count("a") * (n // len(s)) + s[:n % len(s)].count("a"))

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    s = input()

    n = int(input())

    result = repeatedString(s, n)

    fptr.write(str(result) + '\n')

    fptr.close()
