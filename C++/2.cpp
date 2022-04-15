/*
 * @Author: 秦武胜
 * @Date: 2022-04-11 22:01:38
 * @LastEditTime: 2022-04-11 22:01:39
 * @LastEditors: 秦武胜
 * @Description:
 * @FilePath: \MYVSCODE_ON_WINDOWS\C++\2.c
 */

#include <iostream>
using namespace std;

void Print(int *num)
{

    for (int i = 0; i < 5; i++)
    {
        for (int j = i + 1; j < 6; j++)
        {
            for (int k = j + 1; k < 7; k++)
            {
                for (int l = k + 1; k < 8; l++)
                {
                    for (int n = l + 1; n < 9; n++)
                    {
                        for (int m = n + 1; m < 10; m++)
                        {
                            cout << num[i] << num[j] << num[k] << num[l] << num[n] << num[m] << endl;
                        }
                    }
                }
            }
        }
    }
}

//排序
int main()
{

    int num[] = {1, 2, 3, 4, 5, 6, 7, 8, 9};
    Print(num);
    return 0;
}
