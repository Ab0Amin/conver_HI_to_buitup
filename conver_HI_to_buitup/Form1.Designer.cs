namespace conver_HI_to_buitup
{
    partial class Form1
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
            this.button_convert = new System.Windows.Forms.Button();
            this.checkBox_delete_converted_beam = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_convert
            // 
            this.button_convert.Location = new System.Drawing.Point(21, 68);
            this.button_convert.Name = "button_convert";
            this.button_convert.Size = new System.Drawing.Size(75, 23);
            this.button_convert.TabIndex = 0;
            this.button_convert.Text = "convert";
            this.button_convert.UseVisualStyleBackColor = true;
            this.button_convert.Click += new System.EventHandler(this.button_convert_Click);
            // 
            // checkBox_delete_converted_beam
            // 
            this.checkBox_delete_converted_beam.AutoSize = true;
            this.checkBox_delete_converted_beam.Location = new System.Drawing.Point(125, 74);
            this.checkBox_delete_converted_beam.Name = "checkBox_delete_converted_beam";
            this.checkBox_delete_converted_beam.Size = new System.Drawing.Size(91, 17);
            this.checkBox_delete_converted_beam.TabIndex = 1;
            this.checkBox_delete_converted_beam.Text = "delete original";
            this.checkBox_delete_converted_beam.UseVisualStyleBackColor = true;
            this.checkBox_delete_converted_beam.CheckedChanged += new System.EventHandler(this.checkBox_delete_converted_beam_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 179);
            this.Controls.Add(this.checkBox_delete_converted_beam);
            this.Controls.Add(this.button_convert);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_convert;
        private System.Windows.Forms.CheckBox checkBox_delete_converted_beam;
    }
}

