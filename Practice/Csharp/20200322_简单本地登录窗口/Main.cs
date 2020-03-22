using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form_Main : Form
    {
        // 存储账号密码信息
        private Dictionary<string, string> Users = new Dictionary<string, string>();

        // 账号密码临时变量
        public string _indexName = "";
        public string _indexPassword = "";

        // 各级窗口
        From_Error errorForm = new From_Error();
        Form_Explain explainForm = new Form_Explain();
        Form_User user_Form = new Form_User();

        public Form_Main()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            Users.Add("hello", "12345");
        }

        // 登录
        private void LoginButton(object sender, EventArgs e)
        {
            if (!errorForm.IsDisposed)
            {
                errorForm.Close();
                errorForm.Dispose();
            }

            // 账号错误
            if (!Users.ContainsKey(_indexName))
            {
                if (errorForm.IsDisposed)
                    errorForm = new From_Error();
                errorForm.StartPosition = FormStartPosition.CenterScreen;
                errorForm.Show();
            }
            else
            {
                string temp = "";
                Users.TryGetValue(_indexName, out temp);

                // 登录成功
                if (temp.Equals(_indexPassword))
                {
                    if (user_Form.IsDisposed)
                        user_Form = new Form_User();
                    user_Form.Show();
                    user_Form.StartPosition = FormStartPosition.CenterScreen;
                    user_Form.Text = "用户信息";
                    user_Form.label1.Text = "账号：" + _indexName;
                    user_Form.label2.Text = "密码：" + _indexPassword;
                }
                else
                {
                    // 密码错误
                    if (errorForm.IsDisposed)
                        errorForm = new From_Error();
                    errorForm.StartPosition = FormStartPosition.CenterScreen;
                    errorForm.Show();
                }
            }

        }

        // 退出
        private void ExitButton(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 读取输入的账号密码信息
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _indexName = this.textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _indexPassword = this.textBox2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (explainForm.IsDisposed)
                explainForm = new Form_Explain();
            explainForm.Show();
            explainForm.label1.Text = "这是一个简单的C# demo\n测试账号：hello 12345";
        }
    }
}
