源自GitHub的30-seconds-of-code项目. 

原文: <https://github.com/Chalarangelo/30-seconds-of-code>

作者: [Chalarangelo](https://github.com/Chalarangelo)

英文也很通俗易懂, 所以写的时候会中英混杂.

## Snippets for Beginners

#### currentURL

Returns the current URL.

Use `window.location.href` to get current URL.

``` javascript
const currentURL = () => window.location.href;
```

#### everyNth

Returns every nth element in an arry.

Use `Array.filter()` to create a new array that contains every nth element of a given array.

``` javascript
const everyNth = (arr, nth) => arr.filter((e,i) => i % nth === nth - 1);
//注释
//const everyNth2 = (arr, nth) => arr.filter((e,i) => i % nth === 0);
//第一行的把数组第一个元素当做编号1, 上一行的是把数组第一个元素当做编号0;
//example:
arr = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15];
everyNth(arr,4);//[4,8,12];
everyNth2(arr,4);//[1,5,9,13];
```

#### factorial

Calculates the factorial of a number.

Use recursion. If `n` is less than or equal to `1` , return `1` . Otherwise, return the product of `n` and the factorial of `n-1` . Throws an exception if `n` is a negative number.

``` javascript
const factorial = n =>
  n < 0
    ? (() => {
      throw new TypeError('Negative numbers are not allowed!');
    })()
  : n <= 1 ? 1 : n * factorial(n - 1);

console.log(factorial(6));//720
```

#### fibonacci

Generates an array, containing the Fibonacci sequence, up until the nth term.

Create an empty array of the specific length, initializing the first two values ( `0` and `1` ). Use `Array.reduce()` to add values into the array, using the sum of the last two values, except for the first two.

``` javascript
const fibonacci = n =>
  Array(n).fill(0).reduce((acc, val, i) => acc.concat(i > 1 ? acc[i - 1] + acc[i - 2] : i), []);

console.log(fibonacci(5));
//[ 0, 1, 1, 2, 3 ]
```

