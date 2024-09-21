
namespace SortsAlgolabs
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.ArrGenList = new System.Windows.Forms.ComboBox();
            this.GroupChoose = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ArrGen = new System.Windows.Forms.Button();
            this.ArrTest = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.elemBox = new System.Windows.Forms.TextBox();
            this.propaBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(13, 13);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(496, 318);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // ArrGenList
            // 
            this.ArrGenList.FormattingEnabled = true;
            this.ArrGenList.Items.AddRange(new object[] {
            "Стандартные случ. массивы",
            "Частично сорт. массивы",
            "Отсорт. с перестановкой",
            "Отсорт. прямо",
            "Отсорт. обратно",
            "С заменой",
            "С повторением"});
            this.ArrGenList.Location = new System.Drawing.Point(670, 13);
            this.ArrGenList.Name = "ArrGenList";
            this.ArrGenList.Size = new System.Drawing.Size(196, 24);
            this.ArrGenList.TabIndex = 1;
            // 
            // GroupChoose
            // 
            this.GroupChoose.FormattingEnabled = true;
            this.GroupChoose.Items.AddRange(new object[] {
            "Группа 1",
            "Группа 2",
            "Группа 3"});
            this.GroupChoose.Location = new System.Drawing.Point(670, 115);
            this.GroupChoose.Name = "GroupChoose";
            this.GroupChoose.Size = new System.Drawing.Size(196, 24);
            this.GroupChoose.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 339);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(496, 148);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Тип массива:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(516, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Группы алгоритмов:";
            // 
            // ArrGen
            // 
            this.ArrGen.Location = new System.Drawing.Point(709, 43);
            this.ArrGen.Name = "ArrGen";
            this.ArrGen.Size = new System.Drawing.Size(112, 44);
            this.ArrGen.TabIndex = 6;
            this.ArrGen.Text = "Генерировать";
            this.ArrGen.UseVisualStyleBackColor = true;
            this.ArrGen.Click += new System.EventHandler(this.ArrGen_Click);
            // 
            // ArrTest
            // 
            this.ArrTest.Location = new System.Drawing.Point(709, 145);
            this.ArrTest.Name = "ArrTest";
            this.ArrTest.Size = new System.Drawing.Size(112, 44);
            this.ArrTest.TabIndex = 7;
            this.ArrTest.Text = "Тестировать";
            this.ArrTest.UseVisualStyleBackColor = true;
            this.ArrTest.Click += new System.EventHandler(this.ArrTest_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(519, 436);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(346, 50);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Сохранить результаты";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // elemBox
            // 
            this.elemBox.Location = new System.Drawing.Point(575, 347);
            this.elemBox.Name = "elemBox";
            this.elemBox.Size = new System.Drawing.Size(100, 22);
            this.elemBox.TabIndex = 9;
            // 
            // propaBox
            // 
            this.propaBox.Location = new System.Drawing.Point(721, 348);
            this.propaBox.Name = "propaBox";
            this.propaBox.Size = new System.Drawing.Size(100, 22);
            this.propaBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(828, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(551, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Элемент повторения";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(718, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Вероятность";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(689, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "                             ";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 499);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.propaBox);
            this.Controls.Add(this.elemBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ArrTest);
            this.Controls.Add(this.ArrGen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.GroupChoose);
            this.Controls.Add(this.ArrGenList);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ComboBox ArrGenList;
        private System.Windows.Forms.ComboBox GroupChoose;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ArrGen;
        private System.Windows.Forms.Button ArrTest;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox elemBox;
        private System.Windows.Forms.TextBox propaBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

