using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasySlot
{
    public partial class Form1 : Form
    {
        int coin = 1000;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        public Form1()
        {
            InitializeComponent();
            label4.Text = coin.ToString();

            Random r1 = new System.Random();

            //0～９の乱数を生成
            num1 = r1.Next(0, 9);
            num2 = r1.Next(0, 9);
            num3 = r1.Next(0, 9);
            label1.Text = num1.ToString();
            label2.Text = num2.ToString();
            label3.Text = num3.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            if (coin > 0)
            {
                coin--;
            }
            label4.Text= coin.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            num1++;
            if (num1 > 9)
            {
                num1 = 0;
            }
            label1.Text = num1.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            num2++;
            if (num2 > 9)
            {
                num2 = 0;
            }
            label2.Text = num2.ToString();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            num3++;
            if (num3 > 9)
            {
                num3 = 0;
            }
            label3.Text = num3.ToString();
        }
        //停止チェック
        private bool isAllStop()
        {
            return  !timer1.Enabled && !timer2.Enabled && !timer3.Enabled;
        }
        //的中チェック
        private bool isWin()
        {
            return num1==num2 && num2==num3;
        }
        //リザルト処理
        private void Result()
        {
            if (isWin())
            {
                coin += 100;
                if (num1 == 7)
                {
                    //７の場合はさらにプラス
                    coin += 1000;
                }
                label4.Text = coin.ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                button2.Enabled = false;
                if (isAllStop())
                {
                    Result();
                    button1.Enabled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled)
            {
                timer2.Enabled = false;
                button3.Enabled = false;
            }
            if (isAllStop())
            {
                Result();
                button1.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (timer3.Enabled)
            {
                timer3.Enabled = false;
                button4.Enabled = false;
            }
            if (isAllStop())
            {
                Result();
                button1.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
