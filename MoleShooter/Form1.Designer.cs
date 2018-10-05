namespace MoleShooter
{
    partial class shooter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TimerGameLoop = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // TimerGameLoop
            // 
            this.TimerGameLoop.Tick += new System.EventHandler(this.TimerGameLoop_Tick);
            // 
            // shooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MoleShooter.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.DoubleBuffered = true;
            this.Name = "shooter";
            this.Text = "Shooter";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.shooter_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.shooter_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TimerGameLoop;
    }
}

