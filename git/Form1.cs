using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace git
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BStart_click(object sender, EventArgs e)
        {
            // スネークゲーム フォームのインスタンスを生成
            FSnakeGame f_SnakeGame = new FSnakeGame();
            // Showで画面に表示
            // 自分自身のポインタを引数で渡すことで
            // スネークゲームフォームからメニューフォームを操作できる
            f_SnakeGame.Show(this);

            // メニューフォームを隠す（インスタンスは残る）
            Hide(); //tomoki
        }

        private void BEnd_click(object sender, EventArgs e)
        {
            // メニューフォームを閉じる
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("メニューフォームのロード完了");
        }
    }
}
