using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UMLtool
{
    public partial class Form1 : Form
    {
        private List<Node> nodes = new List<Node>();
        private Node currN = null;

        private Node saveN = null;

        private List<Arc> arcs = new List<Arc>();
        private Arc currA = null;

        private List<Comment> comments = new List<Comment>();
        private Comment currC = null;

        private MouseProc mp = null;

        private List<FMInf> copyFields = null;
        private List<FMInf> copyMethods = null;

        private string fileName = "";

        private float bairitu = 1;

        public static Font font;
        public static Font fita;
        public static Font fund;

        public Form1()
        {
            InitializeComponent();
            rbClass.Checked = true;
            rbGen.Checked = true;
            font = new Font("Arial", 9);
            fita = new Font("Arial", 9, FontStyle.Italic);
            fund = new Font("Arial", 9, FontStyle.Underline);
            this.KeyPreview = true;
            //lbRelNum.Size = new Size(109, 32);
        }

        public Node findNode(Point p)
        {
            foreach (Node node in nodes)
                if (node.isIn(p)) return node;
            return null;
        }

        public Arc findArc(Point p)
        {
            foreach (Arc arc in arcs)
                if (arc.isIn(p)) return arc;
            return null;
        }

        public Comment findCom(Point p)
        {
            foreach (Comment c in comments)
                if (c.isIn(p)) return c;
            return null;
        }

        public void setCurrN(Node n) 
        {
            currN = n;
        }

        public void removeArc(Arc a)
        {
            arcs.Remove(a);
            currA = null;
        }

        private void relnameVisible(bool b)
        {
            label5.Visible = b;
            tbRelName.Visible = b;
            tbRelName.Focus();
            label6.Visible = b;
            tbMult.Visible = b;

        }

        private ToolTip tooltip1;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(900, 600);
            tooltip1 = new ToolTip();
            //ToolTipの設定を行う
            //ToolTipが表示されるまでの時間
            tooltip1.InitialDelay = 1000;
            //ToolTipが表示されている時に、別のToolTipを表示するまでの時間
            tooltip1.ReshowDelay = 1000;
            //ToolTipを表示する時間
            tooltip1.AutoPopDelay = 20000;
            //フォームがアクティブでない時でもToolTipを表示する
            tooltip1.ShowAlways = true;

            //Button1とButton2にToolTipが表示されるようにする
            setToolTip();
            cbajust.Checked = true;
            pictureBox1.Size = panel1.Size;
        }
        private void setToolTip()
        {
            tooltip1.SetToolTip(rbClass, "classを設定する");
            tooltip1.SetToolTip(rbAbsclass, "abstract classを設定する");
            tooltip1.SetToolTip(rbInterface, "interfaceを設定する");
            tooltip1.SetToolTip(rbComment, "コメントボックスを設定する");
            tooltip1.SetToolTip(tbName, "class名を入力する");
            tooltip1.SetToolTip(tbField, "フィールド記述を入力する。Enter キー入力で次の行に移る。\r\n上矢印キーで前の行に、下矢印キーで次の行に移る。\r\nShift 上矢印キーで今の行を上に移動、\r\nShift 下矢印キーで今の行を下に移動する。");
            tooltip1.SetToolTip(tbFcopy, "選択要素のフィールド全体のコピー(ctl-C)&ペースト(ctl-V)を行う。");
            tooltip1.SetToolTip(cbFieldStatic, "このフィールドにstaticを設定する");
            tooltip1.SetToolTip(btFieldDel, "このフィールドを(１行)削除する");
            tooltip1.SetToolTip(tbMethod, "メソッド記述を入力する。Enter キー入力で次の行に移る。\r\n上矢印キーで前の行に、下矢印キーで次の行に移る。\r\nShift 上矢印キーで今の行を上に移動、\r\nShift 下矢印キーで今の行を下に移動する。");
            tooltip1.SetToolTip(tbMcopy, "選択要素のメソッド全体のコピー(ctl-C)&ペースト(ctl-V)を行う。");
            tooltip1.SetToolTip(cbMethodAbs, "このメソッドをabstractにする");
            tooltip1.SetToolTip(cbMethodStatic, "このメソッドをstaticにする");
            tooltip1.SetToolTip(btMethodDel, "このメソッドを(１行)削除する");
            tooltip1.SetToolTip(btInherit, "選択要素に対して、汎化関係(－▷)から選択要素の親クラス\r\n(インタフェース)を調べ、必要なメソッドを追加する。\r\nさらに、集約関係(◇→)がある場合、関係の名前を変数名と\r\nしたprivate フィールドを生成する。");
            tooltip1.SetToolTip(rtbComment, "選択されたコメントボックスを記述する");
            tooltip1.SetToolTip(btCommentFont, "選択されたコメントボックスのフォントを設定する");
            tooltip1.SetToolTip(groupBox1, "２つのクラス要素を指定して、その間の関係を生成する。\r\nまず、始点要素を選択する。選択された要素には、上下\r\n左右の枠上に４点の小さい○印が表れるので、そのうち\r\nのいずれかを選びマウスダウンしたままドラッグすると\r\n赤い線が表れる。そのまま終点要素にマウスを持っていく\r\nと、終点要素の枠上に小さい〇が表れるので、そのいずれ\r\nかを選択してマウスをアップすると関係線が引かれる。");
            tooltip1.SetToolTip(rbGen, "汎化関係を設定する");
            tooltip1.SetToolTip(rbAggre, "集約関係を設定する");
            tooltip1.SetToolTip(rbRel, "依存関係を設定する");
            tooltip1.SetToolTip(tbRelName, "集約関係の名前を入力する");
            tooltip1.SetToolTip(tbMult, "集約関係の多重度を記述する。\"0..*\"がdefault値");
            tooltip1.SetToolTip(btTrackBarInit, "画面サイズの拡大縮小を初期値に戻す");
            tooltip1.SetToolTip(trackBar1, "画面を拡大(右移動)・縮小(左移動)する");
            tooltip1.SetToolTip(btDelete, "選択要素(クラス、コメント、関係線など)を削除する");
            tooltip1.SetToolTip(label2, "フィールド記述：\r\n[-|+|#]名前 : 型 [=初期値]\r\n＊ [a]：aはoption、a|b：aまたはb\r\n例　-age : int\r\n    -name : String = \"\"");
            tooltip1.SetToolTip(label3, "メソッド記述：\r\n[+|-|#]名前(引数) [: 戻り型]\r\n＊ [a]：aはoption、a|b：aまたはb\r\n・引数は、空または、\r\n　名前:型 を , で区切り繰り返す。\r\n・コンストラクタは戻り型なし。\r\n例  +setAge(age:int) : void\r\n    +getName() : String");
            tooltip1.SetToolTip(cbajust, "要素の移動で、中心位置をグリッドに微調整動するモードの設定・解除");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rtbComment_TextChanged(object sender, EventArgs e)
        {
            if (currC != null)
            {
                currC.setBody(rtbComment.Text);
                pictureBox1.Invalidate();
            }
        }

        private void fieldUp()
        {
            if (currN != null)
            {
                if (currN.fn > 0 && currN.fn <= currN.inf.fields.Count)
                {
                    currN.fn--;
                    cbFieldStatic.Checked = currN.inf.fields[currN.fn].isStatic;
                    tbField.Text = currN.inf.fields[currN.fn].body;
                }
            }
        }
        private void fieldDown()
        {
            if (currN != null)
            {
                if (currN.fn < currN.inf.fields.Count)
                {
                    currN.fn++;
                }
                if (currN.fn < currN.inf.fields.Count)
                {
                    cbFieldStatic.Checked = currN.inf.fields[currN.fn].isStatic;
                    tbField.Text = currN.inf.fields[currN.fn].body;
                }
                else
                {
                    cbFieldStatic.Checked = false;
                    tbField.Text = "";
                }
            }
        }
        private void fieldMove(bool up)
        {
            if (currN != null)
            {
                if (up && currN.fn < currN.inf.fields.Count - 1)
                {
                    FMInf fm = currN.inf.fields[currN.fn];
                    currN.inf.fields.RemoveAt(currN.fn);
                    currN.fn++;
                    currN.inf.fields.Insert(currN.fn, fm);
                    pictureBox1.Invalidate();
                }
                else if (!up && currN.fn < currN.inf.fields.Count && currN.fn > 0)
                {
                    FMInf fm = currN.inf.fields[currN.fn];
                    currN.inf.fields.RemoveAt(currN.fn);
                    currN.fn--;
                    currN.inf.fields.Insert(currN.fn, fm);
                    pictureBox1.Invalidate();
                }
            }
        }
        private void methodMove(bool up)
        {
            if (currN != null)
            {
                if (up && currN.mn < currN.inf.methods.Count - 1)
                {
                    FMInf fm = currN.inf.methods[currN.mn];
                    currN.inf.methods.RemoveAt(currN.mn);
                    currN.mn++;
                    currN.inf.methods.Insert(currN.mn, fm);
                    pictureBox1.Invalidate();
                }
                else if (!up && currN.mn < currN.inf.methods.Count && currN.mn > 0)
                {
                    FMInf fm = currN.inf.methods[currN.mn];
                    currN.inf.methods.RemoveAt(currN.mn);
                    currN.mn--;
                    currN.inf.methods.Insert(currN.mn, fm);
                    pictureBox1.Invalidate();
                }
            }
        }
        
        private void methodUp()
        {
            if (currN != null)
            {
                if (currN.mn > 0 && currN.mn <= currN.inf.methods.Count)
                {
                    currN.mn--;
                    cbMethodStatic.Checked = currN.inf.methods[currN.mn].isStatic;
                    cbMethodAbs.Checked = currN.inf.methods[currN.mn].isAbstract;
                    tbMethod.Text = currN.inf.methods[currN.mn].body;
                }
            }

        }

        private void methodDown()
        {
            if (currN != null)
            {
                if (currN.mn < currN.inf.methods.Count)
                {
                    currN.mn++;
                }
                if (currN.mn < currN.inf.methods.Count)
                {
                    cbMethodStatic.Checked = currN.inf.methods[currN.mn].isStatic;
                    cbMethodAbs.Checked = currN.inf.methods[currN.mn].isAbstract;
                    tbMethod.Text = currN.inf.methods[currN.mn].body;
                }
                else
                {
                    cbMethodStatic.Checked = false;
                    cbMethodAbs.Checked = false;
                    tbMethod.Text = "";
                }
            }
        }

        private void btLoadJava_Click(object sender, EventArgs e)
        {

        }

        private void btSaveJava_Click(object sender, EventArgs e)
        {

        }

        private void btLoad_Click(object sender, EventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void getClassInf(Node n)
        {
            if (n.inf.ctype == 0)
                rbClass.Checked = true;
            else if (n.inf.ctype == 1)
                rbAbsclass.Checked = true;
            else if (n.inf.ctype == 2)
                rbInterface.Checked = true;
            tbName.Text = n.inf.name;

            if (n.fn < n.inf.fields.Count)
            {
                cbFieldStatic.Checked = n.inf.fields[n.fn].isStatic;
                tbField.Text = n.inf.fields[n.fn].body;
            }
            else
            {
                cbFieldStatic.Checked = false;
                tbField.Text = "";
            }
            if (n.mn < n.inf.methods.Count)
            {
                cbMethodAbs.Checked = n.inf.methods[n.mn].isAbstract;
                cbMethodStatic.Checked = n.inf.methods[n.mn].isStatic;
                tbMethod.Text = n.inf.methods[n.mn].body;
            }
            else
            {
                cbMethodAbs.Checked = false;
                cbMethodStatic.Checked = false;
                tbMethod.Text = "";
            }
        }

        private void clearClassInf()
        {
            //rbClass.Checked = true;
            tbName.Text = "";
            cbFieldStatic.Checked = false;
            tbField.Text = "";
            cbMethodAbs.Checked = false;
            cbMethodStatic.Checked = false;
            tbMethod.Text = "";
        }

        private void clearRelInf()
        {
            tbRelName.Text = "";
            tbMult.Text = "0..*";
        }

        private MouseProc getMouseAction(Point p)
        {
            currN = null;
            currA = null;
            if (currC != null && currC.onPos(p)) //カレントコメントの指示点のとき
            {
                return new ComPosMove(currC); //****コメントの指示点移動
            }
            currC = findCom(p);
            if (currC != null) //コメントのとき
            {
                rtbComment.Text = currC.body;
                rtbComment.Focus();
                return new CommMove(currC);  //****コメント本体の移動
            }
            rtbComment.Text = "";

            currN = findNode(p);
            if (currN != null)  //ノードのとき
            {
                getClassInf(currN); // classの情報を画面左に掲載
                int npos = currN.NPos(p);
                if (npos == 0) //pが東西南北の点でない(つまり、ノードの内部の点)
                {
                    return new NodeMove(this, currN); //****ノード移動
                }
                else //東西南北の点
                {
                    int atype = rbGen.Checked ? 0 : rbAggre.Checked ? 1 : 2; //arcのタイプを設定
                    currA = new Arc(new NodePos(currN, npos), atype); //arcの生成
                    if (atype == 1) //集約
                    {
                        currA.name = tbRelName.Text;
                        tbRelName.Focus();
                        currA.mult = tbMult.Text;
                    }
                    arcs.Add(currA);
                    return new ArcGen(currA, this); //****アーク生成
                }
            }
            else //コメントもノードも指していないとき
            {
                clearClassInf();
            }
            currA = findArc(p);
            if (currA != null) //アークを指しているとき
            {
                if (currA.atype == 0) //汎化
                    rbGen.Checked = true;
                else if (currA.atype == 1) //集約
                {
                    rbAggre.Checked = true;
                    tbRelName.Text = currA.name;
                    tbRelName.Focus();
                    tbMult.Text = currA.mult;
                } //依存
                else
                    rbRel.Checked = true;
            }
            else //なにも指していないとき
            {
                if (rbComment.Checked) //コメント作成がチェックの場合
                {
                    currC = new Comment(p); //コメント要素の生成
                    comments.Add(currC);
                    rtbComment.Focus();
                    return new CommMove(currC); //****コメント本体移動
                }
                else //ノード(class, absClass, interface)作成の場合
                {
                    currN = new Node(p); //ノード生成
                    if (rbAbsclass.Checked)
                        currN.inf.ctype = 1;
                    else if (rbInterface.Checked)
                        currN.inf.ctype = 2;
                    nodes.Add(currN);
                    return new NodeMove(this, currN); //****ノード移動
                }
            }
            return null;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Point loc = new Point((int)(e.X / bairitu), (int)(e.Y / bairitu));
            mp = getMouseAction(loc);
            if (mp != null)
                mp.down(loc);
            pictureBox1.Invalidate();
        }

        public void nodeInfMakeEnable(int area)
        {
            if (area == 0) // Header
                tbName.Focus();
            else if (area == 1) // Field
                tbField.Focus();
            else if (area == 2) // Method
                tbMethod.Focus();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point loc = new Point((int)(e.X / bairitu), (int)(e.Y / bairitu));
            if (mp != null)
            {   
                mp.move(loc);
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Point loc = new Point((int)(e.X / bairitu), (int)(e.Y / bairitu));
            if (mp != null)
            {
                mp.up(loc);
                mp = null;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            resizePictureBox(); //pictureBoxのサイズをデータに合わせて修正
            e.Graphics.ScaleTransform(bairitu, bairitu); //TrackBarの倍率に画面を拡大
            
            foreach (Node nd in nodes) //Nodeを描画
                nd.draw(e);
            if (currN != null)
                currN.drawCurr(e);
            foreach (Arc arc in arcs) //Arcを描画
                arc.draw(e);
            if (currA != null)
                currA.drawCurr(e);
            foreach (Comment com in comments) //Commentを描画
                com.draw(e);
            if (currC != null)
                currC.drawCurr(e);
        }

        //NodeやCommentの位置とTrackBarの倍率に合わせて,pictureBoxのサイズを調整する
        private void resizePictureBox()
        {
            int xm = 0, ym = 0; //xm:x軸の最大、ym:y軸の最大
            foreach (Node n in nodes) //Nodeの位置の最右下を求める
            {
                if (n.rec.X + n.rec.Width > xm)
                    xm = n.rec.X + n.rec.Width;
                if (n.rec.Y + n.rec.Height > ym)
                    ym = n.rec.Y + n.rec.Height;
            }
            foreach (Comment c in comments) //Commentの位置の最右下を求める
            {
                if (c.rec.X + c.rec.Width > xm)
                    xm = c.rec.X + c.rec.Width;
                if (c.rec.Y + c.rec.Height > ym)
                    ym = c.rec.Y + c.rec.Height;
                if (c.pos.X > xm)
                    xm = c.pos.X;
                if (c.pos.Y > ym)
                    ym = c.pos.Y;
            }
            xm += 25; //xm,ymの隙間を25追加する
            ym += 25; 
            xm = (int)(xm * bairitu); //xm,ymをTrack-barの倍率倍にする
            ym = (int)(ym * bairitu);
            if (xm < panel1.Width)    //panelのサイズに合わせる
                xm = panel1.Width;
            if (ym < panel1.Height)
                ym = panel1.Height;
            pictureBox1.Size = new Size(xm, ym); //pictureBoxのリサイズ
        }

        private void rbClass_CheckedChanged(object sender, EventArgs e)
        {
            if (currN != null)
            {
                currN.inf.ctype = 0;
                pictureBox1.Invalidate();
            }
        }

        private void rbAbsclass_CheckedChanged(object sender, EventArgs e)
        {
            if (currN != null)
            {
                currN.inf.ctype = 1;
                pictureBox1.Invalidate();
            }
        }

        private void rbInterface_CheckedChanged(object sender, EventArgs e)
        {
            if (currN != null)
            {
                currN.inf.ctype = 2;
                pictureBox1.Invalidate();
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (currN != null)
            {
                currN.inf.name = tbName.Text;
                pictureBox1.Invalidate();
            }
        }

        private void cbFieldStatic_CheckedChanged(object sender, EventArgs e)
        {
            if (currN != null)
            {
                if (currN.fn < currN.inf.fields.Count)
                {
                    currN.inf.fields[currN.fn].isStatic = cbFieldStatic.Checked;
                    pictureBox1.Invalidate();
                }
            }
        }

        private void tbField_TextChanged(object sender, EventArgs e)
        {
            if (currN != null)
            {
                if (currN.inf.fields.Count == currN.fn && tbField.Text.Replace(" ","") != "")
                {
                    currN.inf.fields.Add(new FMInf());
                    currN.inf.fields[currN.fn].body = tbField.Text;
                    currN.inf.fields[currN.fn].isStatic = cbFieldStatic.Checked;
                    pictureBox1.Invalidate();
                }
                else if (currN.fn < currN.inf.fields.Count)
                {
                    currN.inf.fields[currN.fn].body = tbField.Text;
                    pictureBox1.Invalidate();
                }
            }
        }

        private void cbMethodAbs_CheckedChanged(object sender, EventArgs e)
        {
            if (currN != null)
            {
                if (currN.mn < currN.inf.methods.Count)
                {
                    currN.inf.methods[currN.mn].isAbstract = cbMethodAbs.Checked;
                    pictureBox1.Invalidate();
                }
            }

        }

        private void cbMethodStatic_CheckedChanged(object sender, EventArgs e)
        {
            if (currN != null)
            {
                if (currN.mn < currN.inf.methods.Count)
                {
                    currN.inf.methods[currN.mn].isStatic = cbMethodStatic.Checked;
                    pictureBox1.Invalidate();
                }
            }
        }

        private void tbMethod_TextChanged(object sender, EventArgs e)
        {
            if (currN != null)
            {
                if (currN.inf.methods.Count == currN.mn && tbMethod.Text.Replace(" ","") != "")
                {
                    currN.inf.methods.Add(new FMInf());
                    currN.inf.methods[currN.mn].body = tbMethod.Text;
                    currN.inf.methods[currN.mn].isStatic = cbMethodStatic.Checked;
                    currN.inf.methods[currN.mn].isAbstract = cbMethodAbs.Checked;
                    pictureBox1.Invalidate();
                }
                else if (currN.mn < currN.inf.methods.Count)
                {
                    currN.inf.methods[currN.mn].body = tbMethod.Text;
                    pictureBox1.Invalidate();
                }
            }
        }

        private void btFieldDel_Click(object sender, EventArgs e)
        {
            if (currN != null)
            {
                if (currN.fn < currN.inf.fields.Count)
                {
                    currN.inf.fields.RemoveAt(currN.fn);
                    if (currN.fn < currN.inf.fields.Count)
                    {
                        cbFieldStatic.Checked = currN.inf.fields[currN.fn].isStatic;
                        tbField.Text = currN.inf.fields[currN.fn].body;
                    }
                    else
                    {
                        cbFieldStatic.Checked = false;
                        tbField.Text = "";
                    }
                    pictureBox1.Invalidate();
                }
            }
        }

        private void btMethodDel_Click(object sender, EventArgs e)
        {
            if (currN != null)
            {
                if (currN.mn < currN.inf.methods.Count)
                {
                    currN.inf.methods.RemoveAt(currN.mn);
                    if (currN.mn < currN.inf.methods.Count)
                    {
                        cbMethodStatic.Checked = currN.inf.methods[currN.mn].isStatic;
                        cbMethodAbs.Checked = currN.inf.methods[currN.mn].isAbstract;
                        tbMethod.Text = currN.inf.methods[currN.mn].body;
                    }
                    else
                    {
                        cbMethodStatic.Checked = false;
                        cbMethodAbs.Checked = false;
                        tbMethod.Text = "";
                    }
                    pictureBox1.Invalidate();
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (currN != null)
            {
                nodes.Remove(currN);
                for (int i = arcs.Count - 1; i >= 0; i--)
                    if (arcs[i].n1.n == currN || arcs[i].n2.n == currN)
                        arcs.Remove(arcs[i]);
                currN = null;
                pictureBox1.Invalidate();
            }
            else if (currA != null)
            {
                arcs.Remove(currA);
                currA = null;
                pictureBox1.Invalidate();
            }
            else if (currC != null)
            {
                comments.Remove(currC);
                currC = null;
                pictureBox1.Invalidate();
            }
        }
        

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        // Java→UML生成
        private void javaＵＭＬToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ただいま鋭意開発中ですので、少しお待ちください。");
        }

        private void clearAll()
        {
            nodes.Clear();
            arcs.Clear();
            comments.Clear();
            currN = null;
            currA = null;
            currC = null;

            clearClassInf();
            clearBairitu();
            rtbComment.Text = "";

            setFileName("");
        }

        private void 新規作成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearAll();
            pictureBox1.Invalidate();
        }

        private static Type[] types = { typeof(Node), typeof(Arc), typeof(Comment), typeof(ClassInf), typeof(FMInf), typeof(NodePos)};
        private System.Xml.Serialization.XmlSerializer serializer =
                    new System.Xml.Serialization.XmlSerializer(typeof(Data), types);

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "xml Files|*.xml";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                clearAll();
                setFileName(openFileDialog1.FileName);
                System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
                Data data = (Data)serializer.Deserialize(fs);
                fs.Close();
                nodes = data.nodes;
                arcs = data.arcs;
                if (data.fontstr != "")
                    setFont(data.loadFont());
                comments = data.comments;
                Size sz = new Size(1, 1);
                foreach (Arc arc in arcs)
                {
                    arc.n1.n = findNode(arc.n1.n.rec.Location+sz);
                    arc.n2.n = findNode(arc.n2.n.rec.Location+sz);
                }
                foreach (Comment c in comments)
                    c.loadFont();
                pictureBox1.Invalidate();
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "名前を付けて保存";
            saveFileDialog1.Filter = "xml Files|*.xml";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                setFileName( saveFileDialog1.FileName );
                saveFile(saveFileDialog1.FileName);
            }
        }

        private void setFileName(string fn)
        {
            fileName = fn;
            string fname = "";
            if (fn != "")
            {
                string[] bd = fn.Split(new char[] { '\\' });
                fname = bd.Last().Replace(".xml","") + " - ";
            }

            this.Text = fname + "UML Class Diagram"; 
        }

        private List<Node> copyNode(List<Node> nodes)
        {
            List<Node> nlist = new List<Node>();

            foreach (Node nd in nodes)
            {
                nlist.Add(nd.clone());
            }
            return nlist;
        }
        private List<Arc> copyArc(List<Node> nodes, List<Arc> arcs)
        {
            List<Arc> alist = new List<Arc>();

            foreach (Arc a in arcs)
            {
                Arc an = new Arc();
                an.atype = a.atype;
                an.mult = a.mult;
                an.name = a.name;
                an.n1 = new NodePos();
                an.n1.n = findND(nodes, a.n1.n.rec.Location);
                an.n1.pos = a.n1.pos;
                an.n2 = new NodePos();
                an.n2.n = findND(nodes, a.n2.n.rec.Location);
                an.n2.pos = a.n2.pos;
                alist.Add(an);
            }
            return alist;
        }
        private Node findND(List<Node> nodes, Point p)
        {
            foreach(Node n in nodes)
                if (n.isIn(p)) return n;
            return null;
        }

        // UML→Java生成
        private void java生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<Node> saveNodes = copyNode(nodes);
                List<Arc> saveArcs = copyArc(saveNodes, arcs);
                foreach (Node nd in saveNodes)
                {
                    StreamWriter sw = new StreamWriter(folderBrowserDialog1.SelectedPath + "/" + nd.inf.name + ".java");
                    //makePerfect(nd, saveArcs);
                    sw.Write(getSrc(nd, saveArcs));
                    sw.Close();
                }
            }
        }

        private bool existAL; //ArrayListのimport文生成のためのチェック

        private string getSrc(Node nd, List<Arc> arcs)
        {
            string src = "";

            src += nd.inf.ctype == 0 ? "class " :
                nd.inf.ctype == 1 ? "abstract class " : "interface ";
            src += nd.inf.name + " " + extendsImplements(nd, arcs) + " {\r\n";
            existAL = false;
            foreach(FMInf fm in nd.inf.fields)
                src += getFieldsSrc(fm);
            foreach(FMInf fm in nd.inf.methods)
                src += getMethodsSrc(fm, nd.inf.ctype == 2);
            src += "}\r\n";
            if (existAL)
                src = "import java.util.ArrayList;\r\n" + src;
            return src;
        }
        private string extendsImplements(Node nd, List<Arc> arcs)
        {
            string ext = "", imp = "";
            bool extIsFirst = true, impIsFirst = true;
            foreach (Arc arc in arcs)
            {
                if (arc.n1.n == nd && arc.atype == 0) // ndー▷n2
                {
                    if (arc.n1.n.inf.ctype != 2 && arc.n2.n.inf.ctype == 2) // class -> interface
                    {
                        if (impIsFirst)
                            impIsFirst = false;
                        else
                            imp += ", ";
                        imp += arc.n2.n.inf.name;
                    }
                    else // class -> class or interface -> interface
                    {
                        if(extIsFirst)
                            extIsFirst = false;
                        else
                            ext += ", ";
                        ext += arc.n2.n.inf.name;
                    }
                }
            }
            string ret = "";
            if (ext != "")
                ret += "extends " + ext + " ";
            if (imp != "")
                ret += "implements " + imp + " ";
            return ret;
        }

        private string getFieldsSrc(FMInf fm)
        {
            if (fm.body == "") return "";
            string[] bd = fm.body.Split(new char[] { ':', '=' });
            string pub = "", name = "", type = "", init = "";
            if (bd.Count() > 0)
            {
                name = bd[0].Replace(" ", "").Replace("　", "");
                pub = name[0] == '+' ? "public " : name[0] == '-' ? "private " : name[0] == '#' ? "protected " : "";
                if (pub != "") 
                    name = name.Remove(0, 1);
            }
            if (bd.Count() > 1)
                type = bd[1];
            if (bd.Count() > 2)
                init = bd[2];
            if (type.Contains("ArrayList"))
                existAL = true;
            if (type.Contains("ArrayList") && init == "")
                init = "new " + type + "()";

            return "    " + pub + (fm.isStatic ? "static " : "") + type + " " + name + 
                (init.Replace(" ","") != "" ? "=" + init : "" ) + ";\r\n";
        }

        private string getMethodsSrc(FMInf fm, bool isInterface)
        {
            string body = fm.body.Replace(" ", "").Replace("　", "");
            if (body == "") return "";
            string[] bd = body.Split(new char[]{ '(', ')'});
            string name = "", para = "", type = "", pub = "";

            if (bd.Count() > 0)
            {
                name = bd[0].Replace(" ", "").Replace("　", "");
                pub = name[0] == '+' ? "public " : name[0] == '-' ? "private " : name[0] == '#' ? "protected " : "";
                if (pub != "") 
                    name = name.Remove(0, 1);
            }
            if (bd.Count() > 1)
                para = bd[1].Replace(" ", "").Replace("　", "");
            if (bd.Count() > 2)
            {
                if( bd[2] != "" && bd[2][0]==':')
                    type = bd[2].Remove(0,1);
            }
            if (type.Contains("ArrayList")) 
                existAL = true;

            return "    " + pub + (fm.isAbstract ? "abstract " : "") + (fm.isStatic ? "static " : "") +
                type + " " + name + "(" + getParams(para) + ")" + 
                (fm.isAbstract || isInterface ? ";\r\n" : " {" + getReturn(type) + "\r\n    }\r\n");
        }
        private string getParams(string s)
        {
            string[] ps = s.Split(new char[] { ',' });
            string para = "";
            bool isFst = true;
            foreach(string p in ps)
            {
                string[] nt = p.Split(new char[] { ':' });
                if(nt.Count() > 1) 
                {
                    if (isFst) isFst = false; else para += ",";
                    para += nt[1] + " " + nt[0];
                    if (nt[1].Contains("ArrayList"))
                        existAL = true;
                }
            }
            return para;
        }
        private string getReturn(string s)
        {
            if (s == "int" || s == "float" || s == "double")
                return "\r\n        return 0;";
            else if (s == "String")
                return "\r\n        return \"\";";
            else if (s == "void")
                return "";
            else if (s != "")
                return "\r\n        return null;";
            return "";
        }

        private void 閉じるToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            bairitu = (float)(1.0 + (trackBar1.Value - 5) / 5.0);
            if (bairitu < 0.1) bairitu = (float)0.1;
            if (bairitu > 1.1) bairitu = 1 + (bairitu - 1) * (float)1.5;
            pictureBox1.Invalidate();
        }

        private void clearBairitu()
        {
            bairitu = 1;
            trackBar1.Value = 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearBairitu();
            pictureBox1.Invalidate();
        }

        private void lbRelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currA != null)
            {
                //if (lbRelNum.SelectedItem == null)
                //    currA.mult = "";
                //else
                //    currA.mult = lbRelNum.SelectedItem.ToString();
                //pictureBox1.Invalidate();
            }
        }

        private void tbRelName_TextChanged(object sender, EventArgs e)
        {
            if (currA != null)
            {
                currA.name = tbRelName.Text;
                pictureBox1.Invalidate();
            }
        }

        private void button2_Click(object sender, EventArgs e) //commentのfont設定
        {
            if (currC != null)
            {
                if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    currC.setFont(fontDialog1.Font);
                    pictureBox1.Invalidate();
                }
            }
        }

        private void tbField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && tbField.Text != "")
            {
                fieldDown();
            }
        }


        private void tbMethod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && tbMethod.Text != "")
            {
                methodDown();
            }
            
        }

        private void rbAggre_CheckedChanged(object sender, EventArgs e)
        {
            relnameVisible(rbAggre.Checked);
        }

        private void 画像ファイル生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "画像の生成";
            saveFileDialog1.Filter = "画像ファイル|*.jpg";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                currN = null;
                currA = null;
                currC = null;
                pictureBox1.Invalidate();
                Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                bm.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void btInherit_Click(object sender, EventArgs e)
        {
            if (currN != null)
            {
                makePerfect(currN, arcs);
                pictureBox1.Invalidate();
            }
        }

        private void makePerfect(Node node, List<Arc> arcs)
        {
            if (node.inf.ctype == 2) return;  //nodeがinterfaceなら何もしない
            foreach (string bdy in getAggre(node, arcs)) //集約の処理
            {
                string[] bd = bdy.Split(new char[] { '-', ':' });
                string nm = bd[1].Replace(" ", "");
                if (!isExistInField(node.inf.fields, nm))
                {
                    FMInf fm = new FMInf();
                    fm.body = bdy;
                    node.inf.fields.Add(fm);
                }
            }
            if (node.inf.ctype == 0)  //nodeがabstractなら、継承の処理
            {
                List<FMInf> mlist = new List<FMInf>();
                getInherit(mlist, node, arcs); //親から継承するメソッドのリスト(mlist)を取り出す
                removeExtendsMethods(mlist, node, arcs); //mlistからextends methodsを除く
                foreach (FMInf m in mlist) //implementsすべき全てのメソッドにつき
                {
                    if (m.body != "" && !isExistMethod(node.inf.methods, m)) //存在しなければ
                        node.inf.methods.Add(m); //子クラスのメソッドに追加
                }
                node.mn = 0;
            }
        }
        
        private bool isExistInField(List<FMInf> fls, string name)
        {
            foreach (FMInf fm in fls)
            {
                if (fm.body.Contains(name)) return true;
            }
            return false;
        }
        private List<string> getAggre(Node nd, List<Arc> arcs)
        {
            List<string> bds = new List<string>();
            foreach (Arc arc in arcs)
            {
                if (arc.n1.n == nd && arc.atype == 1 /*集約*/ && arc.name != "")
                {
                    string field = "-" + arc.name + 
                        ((arc.mult.Contains('*') || arc.mult.Contains('n')) ?
                            " : ArrayList<" + arc.n2.n.inf.name + ">" :
                            " : " + arc.n2.n.inf.name);
                    bds.Add(field);
                }
            }
            return bds;
        }

        private bool isExistMethod(List<FMInf> list, FMInf m)
        {
            foreach (FMInf fm in list)
                if (fm.body.Replace(" ", "").Replace("　", "") == m.body.Replace(" ", "").Replace("　", ""))
                    return true;
            return false;
        }
        private void getInherit(List<FMInf> mlist, Node nd, List<Arc> arcs)
        {
            foreach (Arc arc in arcs)
            {
                if (arc.n1.n == nd && arc.atype == 0) // n1 --▷ n2のとき
                {
                    if (arc.n2.n.inf.ctype == 2) //インタフェースをimplementsしている
                    {
                        foreach (FMInf method in arc.n2.n.inf.methods)
                        {
                            FMInf m = new FMInf();
                            m.isAbstract = false;
                            m.isStatic = method.isStatic;
                            m.body = method.body;
                            mlist.Add(m);
                        }
                    }
                    else if (arc.n2.n.inf.ctype == 1) //abstract classをextendsしている
                    {
                        foreach (FMInf method in arc.n2.n.inf.methods)
                            if (method.isAbstract)
                            {
                                FMInf m = new FMInf();
                                m.isAbstract = false;
                                m.isStatic = method.isStatic;
                                m.body = method.body;
                                mlist.Add(m);
                            }
                    }
                    getInherit(mlist, arc.n2.n, arcs);
                }
            }
        }
        private void removeExtendsMethods(List<FMInf> mlist, Node nd, List<Arc> arcs)
        {
            Node ext = null;
            foreach (Arc arc in arcs)
            {
                if (arc.n1.n == nd && arc.atype == 0 && arc.n2.n.inf.ctype != 2) //n1 extends n2
                {
                    ext = arc.n2.n;
                    for (int i = mlist.Count - 1; i >= 0; i--) //mlistからextendsの元のメソッドを消す
                    {
                        foreach (FMInf fm in ext.inf.methods)
                            if (!fm.isAbstract && fm.body.Replace(" ", "") == mlist[i].body.Replace(" ", ""))
                            {
                                mlist.RemoveAt(i);
                                break;
                            }
                    }
                    removeExtendsMethods(mlist, arc.n2.n, arcs);
                }
            }
        }

        private void tbMethod_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (currN != null)
            {
                /*** if (e.Control)
                {
                    if (e.KeyCode == Keys.X) //ctl-x
                        delCurrNode();
                    else if (e.KeyCode == Keys.C)
                        saveN = currN;
                    else if (e.KeyCode == Keys.V)
                    {
                        Point p = System.Windows.Forms.Cursor.Position;
                        if (pictureBox1.ClientRectangle.Contains(pictureBox1.PointToClient(p)))
                            pasteNode(pictureBox1.PointToClient(p));
                        else
                            pasteNode(new Point(20, 20));
                    }
                }
                else***/ if (e.Shift)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        methodMove(false);
                        pictureBox1.Invalidate();
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        methodMove(true);
                        pictureBox1.Invalidate();
                    }
                }
                else
                {
                    if (e.KeyCode == Keys.Up)
                        methodUp();
                    else if (e.KeyCode == Keys.Down)
                        methodDown();
                }
            }
        }

        private void tbField_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (currN != null)
            {
                /*** if (e.Control)
                {
                    if (e.KeyCode == Keys.X) //ctl-x
                        delCurrNode();
                    else if (e.KeyCode == Keys.C)
                        saveN = currN;
                    else if (e.KeyCode == Keys.V)
                    {
                        Point p = System.Windows.Forms.Cursor.Position;
                        if (pictureBox1.ClientRectangle.Contains(pictureBox1.PointToClient(p)))
                            pasteNode(pictureBox1.PointToClient(p));
                        else
                            pasteNode(new Point(20,20));
                    }
                }
                else***/ if (e.Shift)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        fieldMove(false);
                        pictureBox1.Invalidate();
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        fieldMove(true);
                        pictureBox1.Invalidate();
                    }
                }
                else
                {
                    if (e.KeyCode == Keys.Up)
                        fieldUp();
                    else if (e.KeyCode == Keys.Down)
                        fieldDown();
                }
            }
        }

        private void font設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                setFont(fontDialog1.Font);
                pictureBox1.Invalidate();
            }
        }
        private void setFont(Font f)
        {
            font = f;
            fita = new Font(font.Name, font.Size, FontStyle.Italic);
            fund = new Font(font.Name, font.Size, FontStyle.Underline);
        }

        private void tbFcopy_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (currN != null)
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    copyFields = new List<FMInf>();
                    foreach (FMInf fm in currN.inf.fields)
                        if (fm.body.Replace(" ", "").Replace("　", "") != "")
                            copyFields.Add(fm.clone());
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    if (copyFields != null)
                    {
                        foreach (FMInf fm in copyFields)
                        {
                            string bdy = fm.body.Replace(" ", "").Replace("　", "");
                            if (bdy[0] == '-' || bdy[0] == '+' || bdy[0] == '#')
                                bdy = bdy.Remove(0, 1);
                            string[] bd = bdy.Split(new char[] { ':' });
                            if (!isExistInField(currN.inf.fields, bd[0]))
                                currN.inf.fields.Add(fm.clone());
                        }
                    }
                    pictureBox1.Invalidate();
                }
            }
            tbFcopy.Text = "";
        }

        private void tbMcopy_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (currN != null)
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    copyMethods = new List<FMInf>();
                    foreach (FMInf fm in currN.inf.methods)
                        if (fm.body.Replace(" ", "").Replace("　", "") != "")
                            copyMethods.Add(fm.clone());
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    if (copyMethods != null)
                    {
                        foreach (FMInf fm in copyMethods)
                            if (!isExistMethod(currN.inf.methods, fm))
                                currN.inf.methods.Add(fm.clone());
                    }
                    pictureBox1.Invalidate();
                }
            }
            tbMcopy.Text = "";
        }

        private void saveFile(string fn)
        {
            System.IO.FileStream fs = new System.IO.FileStream(fn, System.IO.FileMode.Create);
            Data data = new Data();
            foreach (Comment c in comments)
                c.saveFont();
            data.nodes = nodes;
            data.arcs = arcs;
            data.comments = comments;
            data.saveFont(font);
            serializer.Serialize(fs, data);
            fs.Close();
        }

        private void 上書き保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName != "")
            {
                saveFile(fileName);
            } 
            else if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                setFileName(saveFileDialog1.FileName);
                saveFile(fileName);
            }
        }

        private void マニアルの表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cbajust_CheckedChanged(object sender, EventArgs e)
        {
            NodeMove.setGridMode(cbajust.Checked);
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void tbName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            /*** if (currN != null && e.Control && e.KeyCode == Keys.X)
                delCurrNode(); ***/
        }
        private void delCurrNode()
        {
            saveN = currN;
            nodes.Remove(currN);
            for (int i = arcs.Count - 1; i >= 0; i--)
                if (arcs[i].n1.n == currN || arcs[i].n2.n == currN)
                    arcs.Remove(arcs[i]);
            currN = null;
            pictureBox1.Invalidate();
        }
        private void pasteNode(Point p)
        {
            if (saveN != null)
            {
                Node n = saveN.clone();
                n.rec.Location = p;
                nodes.Add(n);
                currN = n;
                pictureBox1.Invalidate();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            resizePictureBox();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tbMult_TextChanged(object sender, EventArgs e)
        {
            if (currA != null && currA.atype == 1) //カレントアークが集約関係のとき
            {
                currA.mult = tbMult.Text;
                pictureBox1.Invalidate();
            }
        }
    }
}

