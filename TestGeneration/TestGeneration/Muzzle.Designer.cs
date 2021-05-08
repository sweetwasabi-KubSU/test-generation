
namespace WindowsForms
{
    partial class Muzzle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Muzzle));
            this.textNumberOfVariants = new System.Windows.Forms.TextBox();
            this.inputNumberOfVariants = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textNumberOfVariants
            // 
            this.textNumberOfVariants.BackColor = System.Drawing.Color.Lavender;
            this.textNumberOfVariants.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textNumberOfVariants.Location = new System.Drawing.Point(24, 25);
            this.textNumberOfVariants.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textNumberOfVariants.Name = "textNumberOfVariants";
            this.textNumberOfVariants.ReadOnly = true;
            this.textNumberOfVariants.Size = new System.Drawing.Size(149, 19);
            this.textNumberOfVariants.TabIndex = 1;
            this.textNumberOfVariants.Text = "Количество вариантов:";
            // 
            // inputNumberOfVariants
            // 
            this.inputNumberOfVariants.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputNumberOfVariants.Location = new System.Drawing.Point(179, 22);
            this.inputNumberOfVariants.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inputNumberOfVariants.MaxLength = 3;
            this.inputNumberOfVariants.Name = "inputNumberOfVariants";
            this.inputNumberOfVariants.Size = new System.Drawing.Size(117, 26);
            this.inputNumberOfVariants.TabIndex = 0;
            this.inputNumberOfVariants.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputSymbol_KeyPress);
            // 
            // generateButton
            // 
            this.generateButton.BackColor = System.Drawing.Color.LightBlue;
            this.generateButton.Location = new System.Drawing.Point(23, 56);
            this.generateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(273, 53);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Сгенерировать";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(121, 117);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(175, 23);
            this.progressBar.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Lavender;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(23, 118);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(92, 22);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "Выполнение:";
            // 
            // Muzzle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(322, 170);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.inputNumberOfVariants);
            this.Controls.Add(this.textNumberOfVariants);
            this.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Muzzle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Генерация тестов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textNumberOfVariants;
        private System.Windows.Forms.TextBox inputNumberOfVariants;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

