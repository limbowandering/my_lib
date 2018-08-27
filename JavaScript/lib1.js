/*
 * 如何在不满一定数位的数字前补0, 看到一个短的写法:
*/
// https://segmentfault.com/q/1010000002607221
function padNumber(num, fill) {
  //改自：http://blog.csdn.net/aimingoo/article/details/4492592
  let len = ('' + num).length;
  return (Array(fill > len ? fill - len + 1 || 0 : 0).join(0) + num);
}
//觉得这个写的很漂亮
//但是这里有一个数组的开销.

//这是React-Native的一个demo的部分代码 我也感觉写的很好
this.state.text.split(' ').map((word) => word && '🍕').join(' ')
//但愿没人看我的文件吧 啊哈哈哈

