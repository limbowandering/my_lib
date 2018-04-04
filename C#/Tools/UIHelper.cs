using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections;


namespace Tools
{
    public class UIHelper
    {



        /// <summary>
        /// 把一个dataset的内容全部显示在一个listview中
        /// </summary>
        /// <param name="lv"></param>
        public static void InitLisView(DataSet p_ds,ListView lv)
        {

            DataSet ds = p_ds;
            DataTable dt = ds.Tables[0];
            int col_num = dt.Columns.Count; //返回数据集的列数
            int row_num = dt.Rows.Count;    //返回数据集的行数
            
            //设置一些listview的属性
            lv.Clear();
            lv.View = View.Details;
            lv.GridLines = true;
            lv.FullRowSelect = true;




            for (int i_c = 0; i_c < col_num; i_c++)
            {
                ColumnHeader ch = new ColumnHeader();
                ch.Text = dt.Columns[i_c].Caption.ToString();
                lv.Columns.Add(ch);
            }

            //根据数据库返回的查询值填写每个listviewitem，并添加到listview中
            for (int i_r = 0; i_r < row_num; i_r++)
            {
                string[] lvicontent = new string[col_num];//listview中的内容，用一个字符串数组初始化
                for (int i_c = 0; i_c < col_num; i_c++)
                {
                    lvicontent[i_c] = dt.Rows[i_r][i_c].ToString().Trim();
                }
                ListViewItem lvi = new ListViewItem(lvicontent);
                lv.Items.Add(lvi);
            }
        }

        /// <summary>
        /// 把一个dataset的内容全部显示在listview中并指定列的标题
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="col_caption"></param>
        public static void InitLisView(DataSet p_ds,ListView lv, ArrayList col_caption)
        {
            
            DataSet ds = p_ds;
            DataTable dt = ds.Tables[0];
            int col_num = dt.Columns.Count; //返回数据集的列数
            int row_num = dt.Rows.Count;    //返回数据集的行数
            
            //设置一些listview的属性
            lv.Clear();
            lv.View = View.Details;
            lv.GridLines = true;
            lv.FullRowSelect = true;



            if (col_caption.Count != col_num)
            {
                MessageBox.Show("标题与数据列数不符合");
                for (int i_c = 0; i_c < col_num; i_c++)
                {
                    ColumnHeader ch = new ColumnHeader();
                    ch.Text = dt.Columns[i_c].Caption.ToString();
                    lv.Columns.Add(ch);
                }
            }
            else
            {
                for (int i_c = 0; i_c < col_num; i_c++)
                {
                    ColumnHeader ch = new ColumnHeader();
                    ch.Text = col_caption[i_c].ToString();
                    lv.Columns.Add(ch);
                }
            }

            //根据数据库返回的查询值填写每个listviewitem，并添加到listview中
            for (int i_r = 0; i_r < row_num; i_r++)
            {
                string[] lvicontent = new string[col_num];//listview中的内容，用一个字符串数组初始化
                for (int i_c = 0; i_c < col_num; i_c++)
                {
                    lvicontent[i_c] = dt.Rows[i_r][i_c].ToString().Trim();
                }
                ListViewItem lvi = new ListViewItem(lvicontent);
                lv.Items.Add(lvi);
            }
        }


        /// <summary>
        /// 显示dataset中的某几列在listview中
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="colindex"></param>
        public static void InitLisView(DataSet p_ds,ListView lv, int[] colindex)
        {

            DataSet ds = p_ds;
            DataTable dt = ds.Tables[0];
            int col_num = dt.Columns.Count; //返回数据集的列数
            int row_num = dt.Rows.Count;    //返回数据集的行数

            //设置一些listview的属性
            lv.Clear();
            lv.View = View.Details;
            lv.GridLines = true;
            lv.FullRowSelect = true;

            foreach (int check in colindex)
            {
                if (check >= col_num || check < 0)
                {
                    MessageBox.Show("指定的列超过数据集索引范围");
                    return;
                }
            }


            for (int i_c = 0; i_c < colindex.GetLength(0); i_c++)
            {
                ColumnHeader ch = new ColumnHeader();
                ch.Text = dt.Columns[colindex[i_c]].Caption.ToString();
                lv.Columns.Add(ch);
            }

            //根据数据库返回的查询值填写每个listviewitem，并添加到listview中
            for (int i_r = 0; i_r < row_num; i_r++)
            {
                string[] lvicontent = new string[colindex.GetLength(0)];//listview中的内容，用一个字符串数组初始化
                for (int i_c = 0; i_c < colindex.GetLength(0); i_c++)
                {
                    lvicontent[i_c] = dt.Rows[i_r][colindex[i_c]].ToString().Trim();
                }
                ListViewItem lvi = new ListViewItem(lvicontent);
                lv.Items.Add(lvi);
            }
        }

        /// <summary>
        /// 显示dataset中的某几列在listview中并指定标题
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="colindex"></param>
        /// <param name="col_caption"></param>
        public static void InitLisView(DataSet p_ds,ListView lv, int[] colindex, ArrayList col_caption)
        {

            DataSet ds = p_ds;
            DataTable dt = ds.Tables[0];
            int col_num = dt.Columns.Count; //返回数据集的列数
            int row_num = dt.Rows.Count;    //返回数据集的行数

            //设置一些listview的属性
            lv.Clear();
            lv.View = View.Details;
            lv.GridLines = true;
            lv.FullRowSelect = true;


            foreach (int check in colindex)
            {
                if (check >= col_num || check < 0)
                {
                    MessageBox.Show("指定的列超过数据集索引范围");
                    return;
                }
            }

            if (col_caption.Count != colindex.GetLength(0))
            {
                MessageBox.Show("标题与数据列数不符合");
                for (int i_c = 0; i_c < colindex.GetLength(0); i_c++)
                {
                    ColumnHeader ch = new ColumnHeader();
                    ch.Text = dt.Columns[colindex[i_c]].Caption.ToString();
                    lv.Columns.Add(ch);
                }
            }
            else
            {
                for (int i_c = 0; i_c < col_caption.Count; i_c++)
                {
                    ColumnHeader ch = new ColumnHeader();
                    ch.Text = col_caption[i_c].ToString();
                    lv.Columns.Add(ch);
                }
            }

            //根据数据库返回的查询值填写每个listviewitem，并添加到listview中
            for (int i_r = 0; i_r < row_num; i_r++)
            {
                string[] lvicontent = new string[colindex.GetLength(0)];//listview中的内容，用一个字符串数组初始化
                for (int i_c = 0; i_c < colindex.GetLength(0); i_c++)
                {
                    lvicontent[i_c] = dt.Rows[i_r][colindex[i_c]].ToString().Trim();
                }
                ListViewItem lvi = new ListViewItem(lvicontent);
                lv.Items.Add(lvi);
            }
        }

        public static void InitDataGridView(DataSet p_ds,DataGridView dgv)
        {
            DataSet ds = p_ds;
            DataTable dt = ds.Tables[0];
            int col_num = dt.Columns.Count; //返回数据集的列数
            int row_num = dt.Rows.Count;    //返回数据集的行数

            //设置一些datagridview的属性
            dgv.AllowUserToAddRows = false;//不能添加行
            dgv.AllowUserToDeleteRows = false;//不能删除行
            dgv.ReadOnly = true;//不能修改行




            dgv.DataSource = dt;

        }
        public static void InitDataGridView(DataSet p_ds,DataGridView dgv, ArrayList col_caption)
        {
            DataSet ds = p_ds;
            DataTable dt = ds.Tables[0];
            int col_num = dt.Columns.Count; //返回数据集的列数
            int row_num = dt.Rows.Count;    //返回数据集的行数

            //设置一些datagridview的属性
            dgv.AllowUserToAddRows = false;//不能添加行
            dgv.AllowUserToDeleteRows = false;//不能删除行
            dgv.ReadOnly = true;//不能修改行


            dgv.DataSource = dt;

            if (col_caption.Count != col_num)
            {
                MessageBox.Show("标题与数据列数不符合");

            }
            else
            {
                for (int i_c = 0; i_c < col_num; i_c++)
                {

                    dgv.Columns[i_c].HeaderText = col_caption[i_c].ToString();
                }
            }



        }

        public static void InitComboBox(DataSet p_ds,ComboBox cb, int valuecolindex, int displaycolindex)
        {

            DataSet ds = p_ds;
            DataTable dt = ds.Tables[0];
            int col_num = dt.Columns.Count; //返回数据集的列数
            int row_num = dt.Rows.Count;    //返回数据集的行数
            //设置一些combobox的属性
            //cb.SelectedIndex = -1;

            if (displaycolindex >= col_num || displaycolindex < 0)
            {
                MessageBox.Show("指定的显示列超过数据集索引范围");
                return;
            }
            if (valuecolindex >= col_num || valuecolindex < 0)
            {
                MessageBox.Show("指定的索引列超过数据集索引范围");
                return;
            }

            cb.DataSource = dt;
            cb.DisplayMember = dt.Columns[displaycolindex].Caption;
            cb.ValueMember = dt.Columns[valuecolindex].Caption;

        }

        public static void InitListBox(DataSet p_ds,ListBox lb, int colindex)
        {
            //设置一些listbox的属性
            DataSet ds = p_ds;
            DataTable dt = ds.Tables[0];
            int col_num = dt.Columns.Count; //返回数据集的列数
            int row_num = dt.Rows.Count;    //返回数据集的行数

            if (colindex >= col_num || colindex < 0)
            {
                MessageBox.Show("指定的列超过数据集索引范围");
                return;
            }

            for (int i_r = 0; i_r < row_num; i_r++)
            {
                lb.Items.Add(dt.Rows[i_r][colindex].ToString().Trim());
            }

        }

        public static void InitListBox(DataSet p_ds, ListBox lb, int valuecolindex, int displaycolindex)
        {
            //设置一些listbox的属性
            DataSet ds = p_ds;
            DataTable dt = ds.Tables[0];
            int col_num = dt.Columns.Count; //返回数据集的列数
            int row_num = dt.Rows.Count;    //返回数据集的行数


            if (displaycolindex >= col_num || displaycolindex < 0)
            {
                MessageBox.Show("指定的显示列超过数据集索引范围");
                return;
            }
            if (valuecolindex >= col_num || valuecolindex < 0)
            {
                MessageBox.Show("指定的索引列超过数据集索引范围");
                return;
            }

            //for (int i_r = 0; i_r < row_num; i_r++)
            //{
            //    lb.Items.Add(dt.Rows[i_r][colindex].ToString().Trim());
            //}

            lb.DataSource = dt;
            lb.DisplayMember = dt.Columns[displaycolindex].Caption;
            lb.ValueMember = dt.Columns[valuecolindex].Caption;

        }

        public static int GetMTBData(MaskedTextBox p_mtb,string p_memo,out double ret_value)
        {
            if(p_mtb.Text.Trim()==".")
            {
                MessageBox.Show(p_memo+"输入框未填写数据","漏填数据");
                p_mtb.SelectAll();
                p_mtb.Focus();
                ret_value = 0;
                return -1;
            }
            double tmp;
            try
            {
                tmp = Convert.ToDouble(p_mtb.Text.Trim());
            }
            catch (Exception)
            {
                MessageBox.Show(p_memo+"输入框填写的数据不正确","数据不规范");
                
                p_mtb.Focus();
                p_mtb.SelectAll();
                ret_value = 0;
                return -1;
            }
            ret_value = tmp;
            return 0;//正确则返回0
        }

    }
}
