using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using xTrade.Properties;

namespace xTrade
{
    partial class AddReqForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddReqForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxDisc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxTypePay = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerDel = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxPoints = new System.Windows.Forms.ComboBox();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.comboBoxReqPriority = new System.Windows.Forms.ComboBox();
            this.dateTimePickerCr = new System.Windows.Forms.DateTimePicker();
            this.comboBoxReqStatus = new System.Windows.Forms.ComboBox();
            this.comboBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.comboBoxClients = new System.Windows.Forms.ComboBox();
            this.textBoxNumReq = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listViewTv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button4 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxDisc);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.comboBoxTypePay);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBoxNote);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dateTimePickerDel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.comboBoxPoints);
            this.groupBox1.Controls.Add(this.comboBoxCurrency);
            this.groupBox1.Controls.Add(this.comboBoxReqPriority);
            this.groupBox1.Controls.Add(this.dateTimePickerCr);
            this.groupBox1.Controls.Add(this.comboBoxReqStatus);
            this.groupBox1.Controls.Add(this.comboBoxWarehouse);
            this.groupBox1.Controls.Add(this.comboBoxClients);
            this.groupBox1.Controls.Add(this.textBoxNumReq);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 168);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // textBoxDisc
            // 
            this.textBoxDisc.Location = new System.Drawing.Point(526, 93);
            this.textBoxDisc.Name = "textBoxDisc";
            this.textBoxDisc.Size = new System.Drawing.Size(100, 20);
            this.textBoxDisc.TabIndex = 23;
            this.textBoxDisc.Text = "0";
            this.textBoxDisc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDiscKeyPress);
            this.textBoxDisc.Validated += new System.EventHandler(this.TextBoxDiscValidated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(465, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Скидка:";
            // 
            // comboBoxTypePay
            // 
            this.comboBoxTypePay.FormattingEnabled = true;
            this.comboBoxTypePay.Location = new System.Drawing.Point(355, 93);
            this.comboBoxTypePay.Name = "comboBoxTypePay";
            this.comboBoxTypePay.Size = new System.Drawing.Size(84, 21);
            this.comboBoxTypePay.TabIndex = 21;
            this.comboBoxTypePay.Validated += new System.EventHandler(this.ComboBoxClientsValidated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(280, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Тип оплаты:";
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(9, 120);
            this.textBoxNote.Multiline = true;
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(641, 42);
            this.textBoxNote.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Комментарий:";
            // 
            // dateTimePickerDel
            // 
            this.dateTimePickerDel.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDel.Location = new System.Drawing.Point(533, 40);
            this.dateTimePickerDel.Name = "dateTimePickerDel";
            this.dateTimePickerDel.Size = new System.Drawing.Size(93, 20);
            this.dateTimePickerDel.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(465, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Дата дост.:";
            // 
            // comboBoxPoints
            // 
            this.comboBoxPoints.FormattingEnabled = true;
            this.comboBoxPoints.Location = new System.Drawing.Point(56, 66);
            this.comboBoxPoints.Name = "comboBoxPoints";
            this.comboBoxPoints.Size = new System.Drawing.Size(196, 21);
            this.comboBoxPoints.TabIndex = 15;
            this.comboBoxPoints.Validated += new System.EventHandler(this.ComboBoxClientsValidated);
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Location = new System.Drawing.Point(331, 39);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(108, 21);
            this.comboBoxCurrency.TabIndex = 14;
            this.comboBoxCurrency.Validated += new System.EventHandler(this.ComboBoxClientsValidated);
            // 
            // comboBoxReqPriority
            // 
            this.comboBoxReqPriority.FormattingEnabled = true;
            this.comboBoxReqPriority.Location = new System.Drawing.Point(533, 13);
            this.comboBoxReqPriority.Name = "comboBoxReqPriority";
            this.comboBoxReqPriority.Size = new System.Drawing.Size(93, 21);
            this.comboBoxReqPriority.TabIndex = 13;
            this.comboBoxReqPriority.Validated += new System.EventHandler(this.ComboBoxClientsValidated);
            // 
            // dateTimePickerCr
            // 
            this.dateTimePickerCr.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCr.Location = new System.Drawing.Point(177, 13);
            this.dateTimePickerCr.Name = "dateTimePickerCr";
            this.dateTimePickerCr.Size = new System.Drawing.Size(97, 20);
            this.dateTimePickerCr.TabIndex = 12;
            // 
            // comboBoxReqStatus
            // 
            this.comboBoxReqStatus.FormattingEnabled = true;
            this.comboBoxReqStatus.Location = new System.Drawing.Point(331, 12);
            this.comboBoxReqStatus.Name = "comboBoxReqStatus";
            this.comboBoxReqStatus.Size = new System.Drawing.Size(108, 21);
            this.comboBoxReqStatus.TabIndex = 11;
            this.comboBoxReqStatus.Validated += new System.EventHandler(this.ComboBoxClientsValidated);
            // 
            // comboBoxWarehouse
            // 
            this.comboBoxWarehouse.FormattingEnabled = true;
            this.comboBoxWarehouse.Location = new System.Drawing.Point(331, 66);
            this.comboBoxWarehouse.Name = "comboBoxWarehouse";
            this.comboBoxWarehouse.Size = new System.Drawing.Size(295, 21);
            this.comboBoxWarehouse.TabIndex = 10;
            this.comboBoxWarehouse.Validated += new System.EventHandler(this.ComboBoxClientsValidated);
            // 
            // comboBoxClients
            // 
            this.comboBoxClients.FormattingEnabled = true;
            this.comboBoxClients.Location = new System.Drawing.Point(56, 39);
            this.comboBoxClients.Name = "comboBoxClients";
            this.comboBoxClients.Size = new System.Drawing.Size(196, 21);
            this.comboBoxClients.TabIndex = 9;
            this.comboBoxClients.SelectedIndexChanged += new System.EventHandler(this.ComboBoxClientsSelectedIndexChanged);
            this.comboBoxClients.Validated += new System.EventHandler(this.ComboBoxClientsValidated);
            // 
            // textBoxNumReq
            // 
            this.textBoxNumReq.Location = new System.Drawing.Point(56, 13);
            this.textBoxNumReq.Name = "textBoxNumReq";
            this.textBoxNumReq.ReadOnly = true;
            this.textBoxNumReq.Size = new System.Drawing.Size(88, 20);
            this.textBoxNumReq.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Т. точка:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Склад:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(280, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Валюта:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(150, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "от:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(465, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Приоритет:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Статс:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Клиент:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 177);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(656, 179);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listViewTv);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(648, 153);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Товары";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listViewTv
            // 
            this.listViewTv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewTv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTv.FullRowSelect = true;
            this.listViewTv.Location = new System.Drawing.Point(3, 3);
            this.listViewTv.Name = "listViewTv";
            this.listViewTv.Size = new System.Drawing.Size(642, 147);
            this.listViewTv.TabIndex = 0;
            this.listViewTv.UseCompatibleStateImageBehavior = false;
            this.listViewTv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Код";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Наименование";
            this.columnHeader3.Width = 280;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Кол-во";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Цена";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Сумма";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(587, 362);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Отмена";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // button3
            // 
            this.button3.Image = global::xTrade.Properties.Resources.Add;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(480, 362);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Добавить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3Click);
            // 
            // button2
            // 
            this.button2.Image = global::xTrade.Properties.Resources.Remv;
            this.button2.Location = new System.Drawing.Point(94, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 22);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2Click);
            // 
            // button1
            // 
            this.button1.Image = global::xTrade.Properties.Resources.Add;
            this.button1.Location = new System.Drawing.Point(70, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 22);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // AddReqForm
            // 
            this.ClientSize = new System.Drawing.Size(675, 391);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddReqForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить заказ";
            this.Load += new System.EventHandler(this.AddReqFormLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBoxNumReq;
        private ComboBox comboBoxClients;
        private ComboBox comboBoxWarehouse;
        private ComboBox comboBoxReqStatus;
        private DateTimePicker dateTimePickerCr;
        private ComboBox comboBoxPoints;
        private ComboBox comboBoxReqPriority;
        private DateTimePicker dateTimePickerDel;
        private Label label9;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label10;
        private TextBox textBoxNote;
        private ListView listViewTv;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private ComboBox comboBoxTypePay;
        private Label label11;
        private TextBox textBoxDisc;
        private Label label12;
        private ErrorProvider errorProvider1;
        public ComboBox comboBoxCurrency;
    }
}