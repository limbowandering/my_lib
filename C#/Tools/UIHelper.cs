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
        /// ��һ��dataset������ȫ����ʾ��һ��listview��
        /// </summary>
        /// <param name="lv"></param>
        public static void InitLisView(DataSet p_ds,ListView lv)
        {

            DataSet ds = p_ds;
            DataTable dt = ds.Tables[0];
            int col_num = dt.Columns.Count; //�������ݼ�������
            int row_num = dt.Rows.Count;    //�������ݼ�������
            
            //����һЩlistview������
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

            //�������ݿⷵ�صĲ�ѯֵ��дÿ��listviewitem������ӵ�listview��
            for (int i_r = 0; i_r < row_num; i_r++)
            {
                string[] lvicontent = new string[col_num];//listview�е����ݣ���һ���ַ��������ʼ��
                for (int i_c = 0; i_c < col_num; i_c++)
                {
                    lvicontent[i_c] = dt.Rows[i_r][i_c].ToString().Trim();
                }
                ListViewItem lvi = new ListViewItem(lvicontent);
                lv.Items.Add(lvi);
            }
        }

        /// <summary>
        /// ��һ��dataset������ȫ����ʾ��listview�в�ָ���еı���
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="col_caption"></param>
        public static void InitLisView(DataSet p_ds,ListView lv, ArrayList col_caption)
        {
            
            DataSet ds = p_ds;
            DataTable dt = ds.Tables[0];
            int col_num = dt.Columns.Count; //�������ݼ�������
            int row_num = dt.Rows.Count;    //�������ݼ�������
            
            //����һЩlistview������
            lv.Clear();
            lv.View = View.Details;
            lv.GridLines = true;
            lv.FullRowSelect = true;



            if (col_caption.Count != col_num)
            {
                MessageBox.Show("��������������������");
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

            //�������ݿⷵ�صĲ�ѯֵ��дÿ��listviewitem������ӵ�listview��
            for (int i_r = 0; i_r < row_num; i_r++)
            {
                string[] lvicontent = new string[col_num];//listview�е����ݣ���һ���ַ��������ʼ��
                for (int i_c = 0; i_c < col_num; i_c++)
                {
                    lvicontent[i_c] = dt.Rows[i_r][i_c].ToString().Trim();
                }
                ListViewItem lvi = new ListViewItem(lvicontent);
                lv.Items.Add(lvi);
            }
        }


        /// <summary>
        /// ��ʾdataset�е�ĳ������listview��
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="colindex"></param>
        public static void InitLisView(DataSet p_ds,ListView lv, int[] colindex)
        {

            DataSet ds = p_ds;
            DataTable dt = ds.Tables[0];
            int col_num = dt.Columns.Count; //�������ݼ�������
            int row_num = dt.Rows.Count;    //�������ݼ�������

            //����һЩlistview������
            lv.Clear();
            lv.View = View.Details;
            lv.GridLines = true;
            lv.FullRowSelect = true;

            foreach (int check in colindex)
            {
                if (check >= col_num || check < 0)
                {
                    MessageBox.Show("ָ�����г������ݼ�������Χ");
                    return;
                }
            }


            for (int i_c = 0; i_c < colindex.GetLength(0); i_c++)
            {
                ColumnHeader ch = new ColumnHeader();
                ch.Text = dt.Columns[colindex[i_c]].Caption.ToString();
                lv.Columns.Add(ch);
            }

            //�������ݿⷵ�صĲ�ѯֵ��дÿ��listviewitem������ӵ�listview��
            for (int i_r = 0; i_r < row_num; i_r++)
            {
                string[] lvicontent = new string[colindex.GetLength(0)];//listview�е����ݣ���һ���ַ��������ʼ��
                for (int i_c = 0; i_c < colindex.GetLength(0); i_c++)
                {
                    lvicontent[i_c] = dt.Rows[i_r][colindex[i_c]].ToString().Trim();
                }
                ListViewItem lvi = new ListViewItem(lvicontent);
                lv.Items.Add(lvi);
            }
        }

        /// <summary>
        /// ��ʾdataset�е�ĳ������listview�в�ָ������
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="colindex"></param>
        /// <param name="col_caption"></param>
        public static void InitLisView(DataSet p_ds,ListView lv, int[] colindex, ArrayList col_caption)
        {

            DataSet ds = p_ds;
            DataTable dt = ds.Tables[0];
            int col_num = dt.Columns.Count; //�������ݼ�������
            int row_num = dt.Rows.Count;    //�������ݼ�������

            //����һЩlistview������
            lv.Clear();
            lv.View = View.Details;
            lv.GridLines = true;
            lv.FullRowSelect = true;


            foreach (int check in colindex)
            {
                if (check >= col_num || check < 0)
                {
                    MessageBox.Show("ָ�����г������ݼ�������Χ");
                    return;
                }
            }

            if (col_caption.Count != colindex.GetLength(0))
            {
                MessageBox.Show("��������������������");
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

            //�������ݿⷵ�صĲ�ѯֵ��дÿ��listviewitem������ӵ�listview��
            for (int i_r = 0; i_r < row_num; i_r++)
            {
                string[] lvicontent = new string[colindex.GetLength(0)];//listview�е����ݣ���һ���ַ��������ʼ��
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
            int col_num = dt.Columns.Count; //�������ݼ�������
            int row_num = dt.Rows.Count;    //�������ݼ�������

            //����һЩdatagridview������
            dgv.AllowUserToAddRows = false;//���������
            dgv.AllowUserToDeleteRows = false;//����ɾ����
            dgv.ReadOnly = true;//�����޸���




            dgv.DataSource = dt;

        }
        public static void InitDataGridView(DataSet p_ds,DataGridView dgv, ArrayList col_caption)
        {
            DataSet ds = p_ds;
            DataTable dt = ds.Tables[0];
            int col_num = dt.Columns.Count; //�������ݼ�������
            int row_num = dt.Rows.Count;    //�������ݼ�������

            //����һЩdatagridview������
            dgv.AllowUserToAddRows = false;//���������
            dgv.AllowUserToDeleteRows = false;//����ɾ����
            dgv.ReadOnly = true;//�����޸���


            dgv.DataSource = dt;

            if (col_caption.Count != col_num)
            {
                MessageBox.Show("��������������������");

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
            int col_num = dt.Columns.Count; //�������ݼ�������
            int row_num = dt.Rows.Count;    //�������ݼ�������
            //����һЩcombobox������
            //cb.SelectedIndex = -1;

            if (displaycolindex >= col_num || displaycolindex < 0)
            {
                MessageBox.Show("ָ������ʾ�г������ݼ�������Χ");
                return;
            }
            if (valuecolindex >= col_num || valuecolindex < 0)
            {
                MessageBox.Show("ָ���������г������ݼ�������Χ");
                return;
            }

            cb.DataSource = dt;
            cb.DisplayMember = dt.Columns[displaycolindex].Caption;
            cb.ValueMember = dt.Columns[valuecolindex].Caption;

        }

        public static void InitListBox(DataSet p_ds,ListBox lb, int colindex)
        {
            //����һЩlistbox������
            DataSet ds = p_ds;
            DataTable dt = ds.Tables[0];
            int col_num = dt.Columns.Count; //�������ݼ�������
            int row_num = dt.Rows.Count;    //�������ݼ�������

            if (colindex >= col_num || colindex < 0)
            {
                MessageBox.Show("ָ�����г������ݼ�������Χ");
                return;
            }

            for (int i_r = 0; i_r < row_num; i_r++)
            {
                lb.Items.Add(dt.Rows[i_r][colindex].ToString().Trim());
            }

        }

        public static void InitListBox(DataSet p_ds, ListBox lb, int valuecolindex, int displaycolindex)
        {
            //����һЩlistbox������
            DataSet ds = p_ds;
            DataTable dt = ds.Tables[0];
            int col_num = dt.Columns.Count; //�������ݼ�������
            int row_num = dt.Rows.Count;    //�������ݼ�������


            if (displaycolindex >= col_num || displaycolindex < 0)
            {
                MessageBox.Show("ָ������ʾ�г������ݼ�������Χ");
                return;
            }
            if (valuecolindex >= col_num || valuecolindex < 0)
            {
                MessageBox.Show("ָ���������г������ݼ�������Χ");
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
                MessageBox.Show(p_memo+"�����δ��д����","©������");
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
                MessageBox.Show(p_memo+"�������д�����ݲ���ȷ","���ݲ��淶");
                
                p_mtb.Focus();
                p_mtb.SelectAll();
                ret_value = 0;
                return -1;
            }
            ret_value = tmp;
            return 0;//��ȷ�򷵻�0
        }

    }
}
