namespace ProjektPoRadar
{
    partial class FormView
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerMoving = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.drawingBoxOnOf = new System.Windows.Forms.TextBox();
            this.newRouteList = new System.Windows.Forms.ListBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerMoving
            // 
            this.timerMoving.Enabled = true;
            this.timerMoving.Interval = 50;
            this.timerMoving.Tick += new System.EventHandler(this.timerMoving_Tick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(542, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 355);
            this.listBox1.TabIndex = 0;
 
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(694, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(140, 222);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(694, 266);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(140, 23);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Record";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startNewRouteButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(694, 295);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(140, 23);
            this.stopButton.TabIndex = 8;
            this.stopButton.Text = "Apply";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.applyNewRouteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(734, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Set new route";
            // 
            // drawingBoxOnOf
            // 
            this.drawingBoxOnOf.BackColor = System.Drawing.Color.Red;
            this.drawingBoxOnOf.Enabled = false;
            this.drawingBoxOnOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.drawingBoxOnOf.ForeColor = System.Drawing.SystemColors.Info;
            this.drawingBoxOnOf.ImeMode = System.Windows.Forms.ImeMode.On;
            this.drawingBoxOnOf.Location = new System.Drawing.Point(694, 324);
            this.drawingBoxOnOf.Name = "drawingBoxOnOf";
            this.drawingBoxOnOf.ReadOnly = true;
            this.drawingBoxOnOf.Size = new System.Drawing.Size(140, 20);
            this.drawingBoxOnOf.TabIndex = 10;
            this.drawingBoxOnOf.Text = "Recording route...";
            this.drawingBoxOnOf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.drawingBoxOnOf.Visible = false;
            // 
            // newRouteList
            // 
            this.newRouteList.FormattingEnabled = true;
            this.newRouteList.Location = new System.Drawing.Point(852, 12);
            this.newRouteList.Name = "newRouteList";
            this.newRouteList.Size = new System.Drawing.Size(120, 355);
            this.newRouteList.TabIndex = 11;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(852, 373);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(120, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(852, 402);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(120, 23);
            this.loadButton.TabIndex = 13;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(18, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(542, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Resume";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.resumeButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(542, 402);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Pause";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(542, 495);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Generate new map";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.generateNewMapButton_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Enabled = false;
            this.richTextBox2.Location = new System.Drawing.Point(832, 460);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(140, 59);
            this.richTextBox2.TabIndex = 18;
            this.richTextBox2.Text = "Circle - Glider\nSquare - Ballon\nRectangle - Airplane\nEllipse - Helicopter";
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 531);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.newRouteList);
            this.Controls.Add(this.drawingBoxOnOf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 570);
            this.MinimumSize = new System.Drawing.Size(1000, 570);
            this.Name = "FormView";
            this.Text = "Object Moving";

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormView_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormView_MouseClick);

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerMoving;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox drawingBoxOnOf;
        private System.Windows.Forms.ListBox newRouteList;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}

