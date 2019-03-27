namespace ftp_client_1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.result_box = new System.Windows.Forms.TextBox();
            this.local_url = new System.Windows.Forms.TextBox();
            this.listing_box_address = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listing_button = new System.Windows.Forms.Button();
            this.local_directory = new System.Windows.Forms.ListView();
            this.local_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.local_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.local_size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.local_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.local_contextmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.upload_toolstripmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.remote_directory = new System.Windows.Forms.ListView();
            this.remote_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.remote_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.remote_size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.remote_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.remote_attribute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.remote_owner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.remote_contextmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.download_toolstripmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.remote_url = new System.Windows.Forms.TextBox();
            this.local_contextmenu.SuspendLayout();
            this.remote_contextmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // result_box
            // 
            this.result_box.Location = new System.Drawing.Point(10, 372);
            this.result_box.Multiline = true;
            this.result_box.Name = "result_box";
            this.result_box.Size = new System.Drawing.Size(840, 82);
            this.result_box.TabIndex = 4;
            this.result_box.TextChanged += new System.EventHandler(this.result_box_TextChanged);
            // 
            // local_url
            // 
            this.local_url.Location = new System.Drawing.Point(10, 37);
            this.local_url.Name = "local_url";
            this.local_url.Size = new System.Drawing.Size(411, 19);
            this.local_url.TabIndex = 5;
            this.local_url.TextChanged += new System.EventHandler(this.local_url_TextChanged);
            // 
            // listing_box_address
            // 
            this.listing_box_address.Location = new System.Drawing.Point(67, 12);
            this.listing_box_address.Name = "listing_box_address";
            this.listing_box_address.Size = new System.Drawing.Size(702, 19);
            this.listing_box_address.TabIndex = 8;
            this.listing_box_address.TextChanged += new System.EventHandler(this.listing_box_address_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "リスト取得";
            // 
            // listing_button
            // 
            this.listing_button.Location = new System.Drawing.Point(775, 12);
            this.listing_button.Name = "listing_button";
            this.listing_button.Size = new System.Drawing.Size(75, 19);
            this.listing_button.TabIndex = 10;
            this.listing_button.Text = "取得";
            this.listing_button.UseVisualStyleBackColor = true;
            this.listing_button.Click += new System.EventHandler(this.listing_button_Click);
            // 
            // local_directory
            // 
            this.local_directory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.local_name,
            this.local_date,
            this.local_size,
            this.local_type});
            this.local_directory.ContextMenuStrip = this.local_contextmenu;
            this.local_directory.FullRowSelect = true;
            this.local_directory.Location = new System.Drawing.Point(10, 62);
            this.local_directory.Name = "local_directory";
            this.local_directory.Size = new System.Drawing.Size(411, 301);
            this.local_directory.TabIndex = 11;
            this.local_directory.UseCompatibleStateImageBehavior = false;
            this.local_directory.View = System.Windows.Forms.View.Details;
            this.local_directory.SelectedIndexChanged += new System.EventHandler(this.local_directory_SelectedIndexChanged);
            this.local_directory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.local_directory_mouse_double_click);
            // 
            // local_name
            // 
            this.local_name.Text = "名前";
            // 
            // local_date
            // 
            this.local_date.Text = "日付";
            // 
            // local_size
            // 
            this.local_size.Text = "サイズ";
            // 
            // local_type
            // 
            this.local_type.Text = "種類";
            // 
            // local_contextmenu
            // 
            this.local_contextmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upload_toolstripmenu});
            this.local_contextmenu.Name = "local_contextmenu";
            this.local_contextmenu.Size = new System.Drawing.Size(126, 26);
            this.local_contextmenu.Opening += new System.ComponentModel.CancelEventHandler(this.local_contextmenu_Opening);
            // 
            // upload_toolstripmenu
            // 
            this.upload_toolstripmenu.Name = "upload_toolstripmenu";
            this.upload_toolstripmenu.Size = new System.Drawing.Size(125, 22);
            this.upload_toolstripmenu.Text = "アップロード";
            this.upload_toolstripmenu.Click += new System.EventHandler(this.upload_toolstripmenu_Click);
            // 
            // remote_directory
            // 
            this.remote_directory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.remote_name,
            this.remote_date,
            this.remote_size,
            this.remote_type,
            this.remote_attribute,
            this.remote_owner});
            this.remote_directory.ContextMenuStrip = this.remote_contextmenu;
            this.remote_directory.FullRowSelect = true;
            this.remote_directory.Location = new System.Drawing.Point(429, 62);
            this.remote_directory.MultiSelect = false;
            this.remote_directory.Name = "remote_directory";
            this.remote_directory.Size = new System.Drawing.Size(421, 301);
            this.remote_directory.TabIndex = 12;
            this.remote_directory.UseCompatibleStateImageBehavior = false;
            this.remote_directory.View = System.Windows.Forms.View.Details;
            this.remote_directory.SelectedIndexChanged += new System.EventHandler(this.remote_directory_SelectedIndexChanged);
            this.remote_directory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.remote_directory_mouse_double_click);
            // 
            // remote_name
            // 
            this.remote_name.Text = "名前";
            // 
            // remote_date
            // 
            this.remote_date.Text = "日付";
            // 
            // remote_size
            // 
            this.remote_size.Text = "サイズ";
            // 
            // remote_type
            // 
            this.remote_type.Text = "種類";
            // 
            // remote_attribute
            // 
            this.remote_attribute.Text = "属性";
            // 
            // remote_owner
            // 
            this.remote_owner.Text = "所有者";
            // 
            // remote_contextmenu
            // 
            this.remote_contextmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.download_toolstripmenu});
            this.remote_contextmenu.Name = "remote_contextmenu";
            this.remote_contextmenu.Size = new System.Drawing.Size(127, 26);
            this.remote_contextmenu.Opening += new System.ComponentModel.CancelEventHandler(this.remote_contextmenu_Opening);
            // 
            // download_toolstripmenu
            // 
            this.download_toolstripmenu.Name = "download_toolstripmenu";
            this.download_toolstripmenu.Size = new System.Drawing.Size(126, 22);
            this.download_toolstripmenu.Text = "ダウンロード";
            this.download_toolstripmenu.Click += new System.EventHandler(this.download_toolstripmenu_Click);
            // 
            // remote_url
            // 
            this.remote_url.Location = new System.Drawing.Point(429, 37);
            this.remote_url.Name = "remote_url";
            this.remote_url.Size = new System.Drawing.Size(421, 19);
            this.remote_url.TabIndex = 13;
            this.remote_url.TextChanged += new System.EventHandler(this.remote_url_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 463);
            this.Controls.Add(this.remote_url);
            this.Controls.Add(this.remote_directory);
            this.Controls.Add(this.local_directory);
            this.Controls.Add(this.listing_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listing_box_address);
            this.Controls.Add(this.local_url);
            this.Controls.Add(this.result_box);
            this.Name = "Form1";
            this.Text = "Form1";
            this.local_contextmenu.ResumeLayout(false);
            this.remote_contextmenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox result_box;
        private System.Windows.Forms.TextBox local_url;
        private System.Windows.Forms.TextBox listing_box_address;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button listing_button;
        private System.Windows.Forms.ListView local_directory;
        private System.Windows.Forms.ListView remote_directory;
        private System.Windows.Forms.TextBox remote_url;
        private System.Windows.Forms.ColumnHeader local_name;
        private System.Windows.Forms.ColumnHeader local_date;
        private System.Windows.Forms.ColumnHeader local_size;
        private System.Windows.Forms.ColumnHeader local_type;
        private System.Windows.Forms.ColumnHeader remote_name;
        private System.Windows.Forms.ColumnHeader remote_date;
        private System.Windows.Forms.ColumnHeader remote_size;
        private System.Windows.Forms.ColumnHeader remote_type;
        private System.Windows.Forms.ColumnHeader remote_attribute;
        private System.Windows.Forms.ColumnHeader remote_owner;
        private System.Windows.Forms.ContextMenuStrip local_contextmenu;
        private System.Windows.Forms.ToolStripMenuItem upload_toolstripmenu;
        private System.Windows.Forms.ContextMenuStrip remote_contextmenu;
        private System.Windows.Forms.ToolStripMenuItem download_toolstripmenu;
    }
}

