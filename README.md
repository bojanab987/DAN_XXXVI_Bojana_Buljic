Console app, using multithreading, lock, Join...

First thread initialize empty matrix 100x100
Second thread generates 10000 random numbers from 10 to 99, sending sign to first thread to fill out the matrix.
First thread after receiving signal populates the matrix with generated numbers.
Third thread reads all numbers from matrix and adding it to one dimensional array and text file.
Fourth thread reades all data from file and writes it on console.


