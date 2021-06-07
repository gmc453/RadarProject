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
            this.Change_direction = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.drawingBoxOnOf = new System.Windows.Forms.TextBox();
            this.newRouteList = new System.Windows.Forms.ListBox();
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
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
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
            // Change_direction
            // 
            this.Change_direction.Enabled = false;
            this.Change_direction.Location = new System.Drawing.Point(694, 324);
            this.Change_direction.Name = "Change_direction";
            this.Change_direction.Size = new System.Drawing.Size(140, 23);
            this.Change_direction.TabIndex = 2;
            this.Change_direction.Text = "Change direction";
            this.Change_direction.UseVisualStyleBackColor = true;
            this.Change_direction.Click += new System.EventHandler(this.Change_direction_Click);
            this.Change_direction.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Change_direction_MouseClick);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(694, 266);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(140, 23);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(694, 295);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(140, 23);
            this.stopButton.TabIndex = 8;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(734, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Show Route";
            // 
            // drawingBoxOnOf
            // 
            this.drawingBoxOnOf.BackColor = System.Drawing.Color.Red;
            this.drawingBoxOnOf.Enabled = false;
            this.drawingBoxOnOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.drawingBoxOnOf.ForeColor = System.Drawing.SystemColors.Info;
            this.drawingBoxOnOf.ImeMode = System.Windows.Forms.ImeMode.On;
            this.drawingBoxOnOf.Location = new System.Drawing.Point(694, 353);
            this.drawingBoxOnOf.Name = "drawingBoxOnOf";
            this.drawingBoxOnOf.ReadOnly = true;
            this.drawingBoxOnOf.Size = new System.Drawing.Size(140, 20);
            this.drawingBoxOnOf.TabIndex = 10;
            this.drawingBoxOnOf.Text = "Drawing route...";
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
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.Controls.Add(this.newRouteList);
            this.Controls.Add(this.drawingBoxOnOf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.Change_direction);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.listBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "FormView";
            this.Text = "Object Moving";
            this.Load += new System.EventHandler(this.FormView_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormView_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormView_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormView_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormView_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerMoving;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Change_direction;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox drawingBoxOnOf;
        private System.Windows.Forms.ListBox newRouteList;
    }
}

