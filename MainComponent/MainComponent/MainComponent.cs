﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MainComp
{
    public partial class MainComponent : UserControl
    {
        //private PrimaryComponent primaryComp;

       

        private PictureBox pictureBox = null;
        
        private List<ChildComponent.ChildComponent> list;
        
        public MainComponent()
        {
            InitializeComponent();
            pictureBox = new PictureBox();
            //this.SetStyle(ControlStyles.UserPaint, true);
            pictureBox.Invalidate(true);
            pictureBox.Size = new Size(400, 180);

            list = new List<ChildComponent.ChildComponent>();
            foreach (var elem in this.Controls)
            {
                if (elem is ChildComponent.ChildComponent) {
                    list.Add(elem as ChildComponent.ChildComponent);
                }
            }
            list.Reverse();
            foreach (var elem in list)
            {
            LearnToMove(elem);
            }
            
        }

        // private Color colorChild = Color.Blue;
        //[Category("Properties"), Description("Specifies the color of line.")]
        //public Color ColorLineChild
        //{
        //    get
        //    {
        //        return childComponent1.ColorLineChild;
        //    }
        //    set
        //    {
        //        childComponent1.ColorLineChild = value;
        //        Invalidate();
        //    }
        //}

        
        //private ChildComponent.ChildComponent childComponent = childComponent1;
        /// <summary>
        /// Свойства дочернего компонента
        /// </summary>
           
            //теперь они не нужны
            
            //[Category("ChildComponent"), Description("Specifies the background image of child element.")]
            //public Image BackgroundImageChild
            //{
            //    get
            //    {
            //        return list[0].BackgroundImage;
            //    }
            //    set
            //    {
            //        list[0].BackgroundImage = value;
            //        Invalidate();
            //    }
            //}
            //[Category("ChildComponent"), Description("Specifies the location of child element.")]
            //public Point LocationChild
            //{
            //    get
            //    {
            //        return childComponent1.Location;
            //    }
            //    set
            //    {
            //        childComponent1.Location = value;
            //        Invalidate();
            //    }
            //}
            //[Category("ChildComponent"), Description("Specifies the size of child element.")]
            //public Size SizeChild
            //{
            //    get
            //    {
            //        return childComponent1.Size;
            //    }
            //    set
            //    {
            //        childComponent1.Size = value;
            //        Invalidate();
            //    }
            //}

        [Category("ChildComponent"), Description("Specifies the list of child elements.")]
        public List<ChildComponent.ChildComponent> SelectChild
        {
            get
            {
                return list;
            }
            //set
            //{
            //    list = value;
            //    Invalidate();
            //}
        }

        /// <summary>
        /// Свойства Главного компонента
        /// </summary>
        [Category("PrimaryComponent"), Description("Specifies the background image of primary element.")]
        public Image BackgroundImagePrimary
        {
            get
            {
                return primaryComponent1.BackgroundImage;
            }
            set
            {
                primaryComponent1.BackgroundImage = value;
                Invalidate();
            }
        }
        [Category("PrimaryComponent"), Description("Specifies the location of primary element.")]
        public Point LocationPrimary
        {
            get
            {
                return primaryComponent1.Location;
            }
            set
            {
                primaryComponent1.Location = value;
                Invalidate();
            }
        }
        [Category("PrimaryComponent"), Description("Specifies the size of primary element.")]
        public Size SizePrimary
        {
            get
            {
                return primaryComponent1.Size;
            }
            set
            {
                primaryComponent1.Size = value;
                Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(colorLine, 3);
            e.Graphics.DrawRectangle(pen, 1, 1, Width - 3, Height - 3);
            base.OnPaint(e);
        }

        private Color colorLine = Color.Blue;
        [Category("Component"), Description("Specifies the color of line of component.")]
        public Color ColorLine
        {
            get
            {
                return colorLine;
            }
            set
            {
                colorLine = value;
                Invalidate();
            }
        }

        private int errorNumber = 3;
        [Category("Component"), Description("Specifies the error number of component. Value from 1 to 10.")]
        public int ErrorNumber
        {
            get
            {
                return errorNumber;
            }
            set
            {
                if(value >0 && value <= 10)
                    errorNumber = value;
                Invalidate();
            }
        }

        private int clildNumber = 5;
        [Category("Component"), Description("Specifies the number of child component. Value from 5 to 7.")]
        public int ClildNumber
        {
            get
            {
                return clildNumber;
            }
            set
            {
                int lastNum = clildNumber;
                if (value > 4 && value <= 7)
                    clildNumber = value;
                Invalidate();
                if ( clildNumber > lastNum)
                {
                    addChild(clildNumber - lastNum);
                } else if(lastNum > clildNumber)
                {
                    delChild(lastNum - clildNumber);
                }
            }

        }

        private void delChild(int n)
        {
            for (int i = 0; i < n; i++)
            {
                this.Controls.RemoveAt(Controls.Count - 1);
                list.RemoveAt(list.Count-1);
            }
        }

        private void addChild(int n)
        {
            
            for (int i = 0; i < n; i++)
            {
                Random rand = new Random();
                ChildComponent.ChildComponent child = new ChildComponent.ChildComponent();
                child.Location = new Point(rand.Next(230), rand.Next(150));
                //определяем не наложились ли элементы
                bool flag = true;
                while (flag)
                {
                    flag = false;
                    foreach (var elem in list)
                    {
                        if (Math.Abs((elem.Location.X + 13) - (child.Location.X + 13)) < 30 &&
                            Math.Abs((elem.Location.Y + 13) - (child.Location.Y + 13)) < 30 || 
                            child.Location.X <5 || child.Location.Y < 5 || child.Location.Y > 150)
                        {
                            child.Location = new Point(rand.Next(230), rand.Next(140));
                            flag = true;
                        }
                    }
                }



                Controls.Add(child);
                
                list.Add(child);
                LearnToMove(child);
            }
        }

        private void childComponent1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void childComponent1_Click(object sender, EventArgs e)
        {

        }

        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public override Size Size
        //{
        //    get { return base.Size; }
        //    set { base.Size = value; }
        //}
        // события для движения
        static bool isPress = false;
        static Point startPst;
        /// <summary>
        /// Функция выполняется при нажатии на перемещаемый контрол
        /// </summary>
        /// <param name="sender">контролл</param>
        /// <param name="e">событие мышки</param>
        private static void mDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;//проверка что нажата левая кнопка
            isPress = true;
            startPst = e.Location;
        }
        /// <summary>
        /// Функция выполняется при отжатии перемещаемого контрола
        /// </summary>
        /// <param name="sender">контролл</param>
        /// <param name="e">событие мышки</param>
        private static void mUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;//проверка что нажата левая кнопка
            isPress = false;
        }
        /// <summary>
        /// Функция выполняется при перемещении контрола
        /// </summary>
        /// <param name="sender">контролл</param>
        /// <param name="e">событие мышки</param>
        private static void mMove(object sender, MouseEventArgs e)
        {
            if (isPress)
            {
                Control control = (Control)sender;
                control.Top += e.Y - startPst.Y;
                control.Left += e.X - startPst.X;
            }
        }
        /// <summary>
        /// обучает контролы передвигаться
        /// </summary>
        /// <param name="sender">контролл(это может быть кнопка, лейбл, календарик и.т.д)</param>
        public static void LearnToMove(object sender)
        {
            Control control = (Control)sender;
            control.MouseDown += new MouseEventHandler(mDown);
            control.MouseUp += new MouseEventHandler(mUp);
            control.MouseMove += new MouseEventHandler(mMove);
        }
    }
    
}
