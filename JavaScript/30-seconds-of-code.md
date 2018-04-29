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

