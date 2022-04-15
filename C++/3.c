/*
 * @Author: 秦武胜
 * @Date: 2022-04-11 22:27:35
 * @LastEditTime: 2022-04-11 22:39:24
 * @LastEditors: 秦武胜
 * @Description:
 * @FilePath: \MYVSCODE_ON_WINDOWS\C++\3.c
 */

#include <stdio.h>

void Print()
{
    int n[5] = {1, 2, 3, 4, 5};

    for (int i = 0; i < 4; i++)
    {
        for (int j = i + 1; j < 3; j++)
        {
            for (int k = j + 1; k < 5; k++)
            {
                printf("%d%d%d\n", n[i], n[j], n[k]);
            }
        }
        printf("\n");
    }
}

void main()
{

    Print();
}