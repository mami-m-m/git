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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            // 自動で生成される関数
            // デザイナー画面で追加した部品を初期化してくれます。
            // この関数の中身を下手にいじるとデザイナーと不整合が起こるので
            // 触らないでください。
            InitializeComponent();

            // フィールドの大きさに合わせてフォームサイズを調整
            this.ClientSize = new System.Drawing.Size(20 + 55 * CConstants.WIDTH, 20 + 55 * CConstants.HEIGHT);

            // フィールドの大きさに合わせてパネルサイズを調整
            this.P_Field.Size = new System.Drawing.Size(55 * CConstants.WIDTH, 55 * CConstants.HEIGHT);

            //ResumeLayout()が呼び出されるまで、複数のLayoutイベントが発生しないようにする
            SuspendLayout();

            //PictureBoxをフィールドのマスの分だけ生成する
            for (int i = 0; i < CConstants.WIDTH; i++)
            {
                for (int j = 0; j < CConstants.HEIGHT; j++)
                {
                    // インスタンスの生成
                    Pbox[i, j] = new PictureBox();
                    P_Field.Controls.Add(Pbox[i, j]);
                    Pbox[i, j].Name = "Pbox[" + i.ToString() + "][" + j.ToString() + "]";
                    Pbox[i, j].Location = new Point((55 * i), (55 * j));
                    Pbox[i, j].Size = new Size(50, 50);
                }
            }
            ResumeLayout();

            // 自分で定期的に初期化したい変数や処理をinit()関数にまとめて呼び出す。
            init();

        }

        private void init()
        {
            m_inKeyDir = CConstants.Direction.left;
            m_snake.initSnake();
            m_food.makeFood(m_snake.getPos(), m_snake.getLength());
            // 壁は最初に1度だけ描画して、以降そのままにしておく
            for (int i = 0; i < CConstants.HEIGHT; i++)
            {
                for (int j = 0; j < CConstants.WIDTH; j++)
                {
                    if (i == 0 || i == (CConstants.HEIGHT - 1) || j == 0 || j == (CConstants.WIDTH - 1)) m_Pbox[i, j].ImageLocation = @"wall.png";
                }
            }
            // タイマーを有効にする
            this.T_CycleTimer.Enabled = true;
        }

        // メンバ変数
        private PictureBox[,] m_Pbox = new PictureBox[CConstants.WIDTH, CConstants.HEIGHT];
        private CSnake m_snake = new CSnake();
        // 入力されたキーを記憶しておき、タイマーが発火時に進める
        private CConstants.Direction m_inKeyDir;
        private CFood m_food = new CFood();

        // 定数用クラス
        static class CConstants
        {
            // フィールドの横幅と縦幅
            public const int WIDTH = 10;
            public const int HEIGHT = 10;

            // スネークの頭の初期位置
            public const int STARTX = WIDTH / 2;
            public const int STARTY = HEIGHT / 2;

            // スネークの最大長
            public const int SNAKE_MAX_LENGTH = (WIDTH - 2) * (HEIGHT - 2);

            // キー入力用定数
            public enum Direction
            {
                left,
                up,
                right,
                down,
                non
            };
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FSnakeGame_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                // 入力されたキーに対応する定数を格納する
                case Keys.Left:
                    m_inKeyDir = CConstants.Direction.left;
                    break;
                case Keys.Up:
                    m_inKeyDir = CConstants.Direction.up;
                    break;
                case Keys.Right:
                    m_inKeyDir = CConstants.Direction.right;
                    break;
                case Keys.Down:
                    m_inKeyDir = CConstants.Direction.down;
                    break;
                default:
                    // 何もしない
                    break;
            }
        }
    }

}
