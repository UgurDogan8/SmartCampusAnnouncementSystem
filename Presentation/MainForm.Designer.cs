#nullable enable

namespace SmartCampusAnnouncementSystem.Presentation;

partial class MainForm
{
    private System.ComponentModel.IContainer? components = null;
    private TableLayoutPanel mainLayout = null!;
    private TableLayoutPanel contentLayout = null!;
    private TableLayoutPanel leftLayout = null!;
    private TableLayoutPanel rightLayout = null!;
    private FlowLayoutPanel commandPanel = null!;
    private GroupBox grpAddUser = null!;
    private GroupBox grpUsers = null!;
    private GroupBox grpAnnouncement = null!;
    private GroupBox grpLogs = null!;
    private TableLayoutPanel addUserLayout = null!;
    private TableLayoutPanel announcementLayout = null!;
    private TableLayoutPanel logLayout = null!;
    private Label lblFullName = null!;
    private Label lblUserType = null!;
    private Label lblNotificationPreference = null!;
    private Label lblAnnouncementType = null!;
    private Label lblTargetUserType = null!;
    private Label lblTitle = null!;
    private Label lblContent = null!;
    private TextBox txtFullName = null!;
    private TextBox txtTitle = null!;
    private ComboBox cmbUserType = null!;
    private ComboBox cmbNotificationPreference = null!;
    private ComboBox cmbAnnouncementType = null!;
    private ComboBox cmbTargetUserType = null!;
    private Button btnAddUser = null!;
    private Button btnPublishAnnouncement = null!;
    private Button btnClearLog = null!;
    private Button btnLoadDemo = null!;
    private Button btnClearForm = null!;
    private DataGridView dgvUsers = null!;
    private RichTextBox rtbContent = null!;
    private RichTextBox rtbNotificationLog = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        mainLayout = new TableLayoutPanel();
        contentLayout = new TableLayoutPanel();
        leftLayout = new TableLayoutPanel();
        rightLayout = new TableLayoutPanel();
        commandPanel = new FlowLayoutPanel();
        grpAddUser = new GroupBox();
        grpUsers = new GroupBox();
        grpAnnouncement = new GroupBox();
        grpLogs = new GroupBox();
        addUserLayout = new TableLayoutPanel();
        announcementLayout = new TableLayoutPanel();
        logLayout = new TableLayoutPanel();
        lblFullName = new Label();
        lblUserType = new Label();
        lblNotificationPreference = new Label();
        lblAnnouncementType = new Label();
        lblTargetUserType = new Label();
        lblTitle = new Label();
        lblContent = new Label();
        txtFullName = new TextBox();
        txtTitle = new TextBox();
        cmbUserType = new ComboBox();
        cmbNotificationPreference = new ComboBox();
        cmbAnnouncementType = new ComboBox();
        cmbTargetUserType = new ComboBox();
        btnAddUser = new Button();
        btnPublishAnnouncement = new Button();
        btnClearLog = new Button();
        btnLoadDemo = new Button();
        btnClearForm = new Button();
        dgvUsers = new DataGridView();
        rtbContent = new RichTextBox();
        rtbNotificationLog = new RichTextBox();
        mainLayout.SuspendLayout();
        contentLayout.SuspendLayout();
        leftLayout.SuspendLayout();
        rightLayout.SuspendLayout();
        commandPanel.SuspendLayout();
        grpAddUser.SuspendLayout();
        grpUsers.SuspendLayout();
        grpAnnouncement.SuspendLayout();
        grpLogs.SuspendLayout();
        addUserLayout.SuspendLayout();
        announcementLayout.SuspendLayout();
        logLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
        SuspendLayout();
        // 
        // mainLayout
        // 
        mainLayout.ColumnCount = 1;
        mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mainLayout.Controls.Add(contentLayout, 0, 0);
        mainLayout.Controls.Add(commandPanel, 0, 1);
        mainLayout.Dock = DockStyle.Fill;
        mainLayout.Location = new Point(0, 0);
        mainLayout.Name = "mainLayout";
        mainLayout.Padding = new Padding(12);
        mainLayout.RowCount = 2;
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
        mainLayout.Size = new Size(1100, 700);
        mainLayout.TabIndex = 0;
        // 
        // contentLayout
        // 
        contentLayout.ColumnCount = 2;
        contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        contentLayout.Controls.Add(leftLayout, 0, 0);
        contentLayout.Controls.Add(rightLayout, 1, 0);
        contentLayout.Dock = DockStyle.Fill;
        contentLayout.Location = new Point(15, 15);
        contentLayout.Name = "contentLayout";
        contentLayout.RowCount = 1;
        contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        contentLayout.Size = new Size(1070, 614);
        contentLayout.TabIndex = 0;
        // 
        // leftLayout
        // 
        leftLayout.ColumnCount = 1;
        leftLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        leftLayout.Controls.Add(grpAddUser, 0, 0);
        leftLayout.Controls.Add(grpUsers, 0, 1);
        leftLayout.Dock = DockStyle.Fill;
        leftLayout.Location = new Point(0, 0);
        leftLayout.Margin = new Padding(0, 0, 8, 0);
        leftLayout.Name = "leftLayout";
        leftLayout.RowCount = 2;
        leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 230F));
        leftLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        leftLayout.Size = new Size(420, 614);
        leftLayout.TabIndex = 0;
        // 
        // rightLayout
        // 
        rightLayout.ColumnCount = 1;
        rightLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rightLayout.Controls.Add(grpAnnouncement, 0, 0);
        rightLayout.Controls.Add(grpLogs, 0, 1);
        rightLayout.Dock = DockStyle.Fill;
        rightLayout.Location = new Point(436, 0);
        rightLayout.Margin = new Padding(8, 0, 0, 0);
        rightLayout.Name = "rightLayout";
        rightLayout.RowCount = 2;
        rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 315F));
        rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rightLayout.Size = new Size(634, 614);
        rightLayout.TabIndex = 1;
        // 
        // commandPanel
        // 
        commandPanel.Controls.Add(btnClearForm);
        commandPanel.Controls.Add(btnLoadDemo);
        commandPanel.Dock = DockStyle.Fill;
        commandPanel.FlowDirection = FlowDirection.RightToLeft;
        commandPanel.Location = new Point(15, 635);
        commandPanel.Name = "commandPanel";
        commandPanel.Padding = new Padding(0, 8, 0, 0);
        commandPanel.Size = new Size(1070, 50);
        commandPanel.TabIndex = 1;
        // 
        // grpAddUser
        // 
        grpAddUser.Controls.Add(addUserLayout);
        grpAddUser.Dock = DockStyle.Fill;
        grpAddUser.Location = new Point(3, 3);
        grpAddUser.Name = "grpAddUser";
        grpAddUser.Padding = new Padding(12);
        grpAddUser.Size = new Size(414, 224);
        grpAddUser.TabIndex = 0;
        grpAddUser.TabStop = false;
        grpAddUser.Text = "Kullanıcı Ekle";
        // 
        // addUserLayout
        // 
        addUserLayout.ColumnCount = 2;
        addUserLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
        addUserLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        addUserLayout.Controls.Add(lblFullName, 0, 0);
        addUserLayout.Controls.Add(txtFullName, 1, 0);
        addUserLayout.Controls.Add(lblUserType, 0, 1);
        addUserLayout.Controls.Add(cmbUserType, 1, 1);
        addUserLayout.Controls.Add(lblNotificationPreference, 0, 2);
        addUserLayout.Controls.Add(cmbNotificationPreference, 1, 2);
        addUserLayout.Controls.Add(btnAddUser, 1, 3);
        addUserLayout.Dock = DockStyle.Fill;
        addUserLayout.Location = new Point(12, 28);
        addUserLayout.Name = "addUserLayout";
        addUserLayout.RowCount = 4;
        addUserLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        addUserLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        addUserLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        addUserLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        addUserLayout.Size = new Size(390, 184);
        addUserLayout.TabIndex = 0;
        // 
        // lblFullName
        // 
        lblFullName.AutoSize = true;
        lblFullName.Dock = DockStyle.Fill;
        lblFullName.Location = new Point(3, 0);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new Size(134, 42);
        lblFullName.TabIndex = 0;
        lblFullName.Text = "Ad Soyad";
        lblFullName.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtFullName
        // 
        txtFullName.Dock = DockStyle.Fill;
        txtFullName.Location = new Point(143, 7);
        txtFullName.Margin = new Padding(3, 7, 3, 3);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new Size(244, 25);
        txtFullName.TabIndex = 1;
        // 
        // lblUserType
        // 
        lblUserType.AutoSize = true;
        lblUserType.Dock = DockStyle.Fill;
        lblUserType.Location = new Point(3, 42);
        lblUserType.Name = "lblUserType";
        lblUserType.Size = new Size(134, 42);
        lblUserType.TabIndex = 2;
        lblUserType.Text = "Kullanıcı Tipi";
        lblUserType.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // cmbUserType
        // 
        cmbUserType.Dock = DockStyle.Fill;
        cmbUserType.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbUserType.FormattingEnabled = true;
        cmbUserType.Location = new Point(143, 49);
        cmbUserType.Margin = new Padding(3, 7, 3, 3);
        cmbUserType.Name = "cmbUserType";
        cmbUserType.Size = new Size(244, 25);
        cmbUserType.TabIndex = 3;
        // 
        // lblNotificationPreference
        // 
        lblNotificationPreference.AutoSize = true;
        lblNotificationPreference.Dock = DockStyle.Fill;
        lblNotificationPreference.Location = new Point(3, 84);
        lblNotificationPreference.Name = "lblNotificationPreference";
        lblNotificationPreference.Size = new Size(134, 42);
        lblNotificationPreference.TabIndex = 4;
        lblNotificationPreference.Text = "Bildirim Tercihi";
        lblNotificationPreference.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // cmbNotificationPreference
        // 
        cmbNotificationPreference.Dock = DockStyle.Fill;
        cmbNotificationPreference.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbNotificationPreference.FormattingEnabled = true;
        cmbNotificationPreference.Location = new Point(143, 91);
        cmbNotificationPreference.Margin = new Padding(3, 7, 3, 3);
        cmbNotificationPreference.Name = "cmbNotificationPreference";
        cmbNotificationPreference.Size = new Size(244, 25);
        cmbNotificationPreference.TabIndex = 5;
        // 
        // btnAddUser
        // 
        btnAddUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnAddUser.Location = new Point(248, 134);
        btnAddUser.Margin = new Padding(3, 8, 3, 3);
        btnAddUser.Name = "btnAddUser";
        btnAddUser.Size = new Size(139, 32);
        btnAddUser.TabIndex = 6;
        btnAddUser.Text = "Kullanıcı Ekle";
        btnAddUser.UseVisualStyleBackColor = true;
        btnAddUser.Click += btnAddUser_Click;
        // 
        // grpUsers
        // 
        grpUsers.Controls.Add(dgvUsers);
        grpUsers.Dock = DockStyle.Fill;
        grpUsers.Location = new Point(3, 233);
        grpUsers.Name = "grpUsers";
        grpUsers.Padding = new Padding(12);
        grpUsers.Size = new Size(414, 378);
        grpUsers.TabIndex = 1;
        grpUsers.TabStop = false;
        grpUsers.Text = "Kayıtlı Kullanıcılar";
        // 
        // dgvUsers
        // 
        dgvUsers.AllowUserToAddRows = false;
        dgvUsers.AllowUserToDeleteRows = false;
        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvUsers.Dock = DockStyle.Fill;
        dgvUsers.Location = new Point(12, 28);
        dgvUsers.MultiSelect = false;
        dgvUsers.Name = "dgvUsers";
        dgvUsers.ReadOnly = true;
        dgvUsers.RowHeadersVisible = false;
        dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvUsers.Size = new Size(390, 338);
        dgvUsers.TabIndex = 0;
        // 
        // grpAnnouncement
        // 
        grpAnnouncement.Controls.Add(announcementLayout);
        grpAnnouncement.Dock = DockStyle.Fill;
        grpAnnouncement.Location = new Point(3, 3);
        grpAnnouncement.Name = "grpAnnouncement";
        grpAnnouncement.Padding = new Padding(12);
        grpAnnouncement.Size = new Size(628, 309);
        grpAnnouncement.TabIndex = 0;
        grpAnnouncement.TabStop = false;
        grpAnnouncement.Text = "Duyuru Oluştur";
        // 
        // announcementLayout
        // 
        announcementLayout.ColumnCount = 2;
        announcementLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        announcementLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        announcementLayout.Controls.Add(lblAnnouncementType, 0, 0);
        announcementLayout.Controls.Add(cmbAnnouncementType, 1, 0);
        announcementLayout.Controls.Add(lblTargetUserType, 0, 1);
        announcementLayout.Controls.Add(cmbTargetUserType, 1, 1);
        announcementLayout.Controls.Add(lblTitle, 0, 2);
        announcementLayout.Controls.Add(txtTitle, 1, 2);
        announcementLayout.Controls.Add(lblContent, 0, 3);
        announcementLayout.Controls.Add(rtbContent, 1, 3);
        announcementLayout.Controls.Add(btnPublishAnnouncement, 1, 4);
        announcementLayout.Dock = DockStyle.Fill;
        announcementLayout.Location = new Point(12, 28);
        announcementLayout.Name = "announcementLayout";
        announcementLayout.RowCount = 5;
        announcementLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        announcementLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        announcementLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        announcementLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        announcementLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        announcementLayout.Size = new Size(604, 269);
        announcementLayout.TabIndex = 0;
        // 
        // lblAnnouncementType
        // 
        lblAnnouncementType.AutoSize = true;
        lblAnnouncementType.Dock = DockStyle.Fill;
        lblAnnouncementType.Location = new Point(3, 0);
        lblAnnouncementType.Name = "lblAnnouncementType";
        lblAnnouncementType.Size = new Size(114, 40);
        lblAnnouncementType.TabIndex = 0;
        lblAnnouncementType.Text = "Duyuru Tipi";
        lblAnnouncementType.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // cmbAnnouncementType
        // 
        cmbAnnouncementType.Dock = DockStyle.Fill;
        cmbAnnouncementType.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbAnnouncementType.FormattingEnabled = true;
        cmbAnnouncementType.Location = new Point(123, 7);
        cmbAnnouncementType.Margin = new Padding(3, 7, 3, 3);
        cmbAnnouncementType.Name = "cmbAnnouncementType";
        cmbAnnouncementType.Size = new Size(478, 25);
        cmbAnnouncementType.TabIndex = 1;
        // 
        // lblTargetUserType
        // 
        lblTargetUserType.AutoSize = true;
        lblTargetUserType.Dock = DockStyle.Fill;
        lblTargetUserType.Location = new Point(3, 40);
        lblTargetUserType.Name = "lblTargetUserType";
        lblTargetUserType.Size = new Size(114, 40);
        lblTargetUserType.TabIndex = 2;
        lblTargetUserType.Text = "Hedef Kullanıcı";
        lblTargetUserType.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // cmbTargetUserType
        // 
        cmbTargetUserType.Dock = DockStyle.Fill;
        cmbTargetUserType.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTargetUserType.FormattingEnabled = true;
        cmbTargetUserType.Location = new Point(123, 47);
        cmbTargetUserType.Margin = new Padding(3, 7, 3, 3);
        cmbTargetUserType.Name = "cmbTargetUserType";
        cmbTargetUserType.Size = new Size(478, 25);
        cmbTargetUserType.TabIndex = 3;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Location = new Point(3, 80);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(114, 40);
        lblTitle.TabIndex = 4;
        lblTitle.Text = "Başlık";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtTitle
        // 
        txtTitle.Dock = DockStyle.Fill;
        txtTitle.Location = new Point(123, 87);
        txtTitle.Margin = new Padding(3, 7, 3, 3);
        txtTitle.Name = "txtTitle";
        txtTitle.Size = new Size(478, 25);
        txtTitle.TabIndex = 5;
        // 
        // lblContent
        // 
        lblContent.AutoSize = true;
        lblContent.Dock = DockStyle.Fill;
        lblContent.Location = new Point(3, 120);
        lblContent.Name = "lblContent";
        lblContent.Size = new Size(114, 105);
        lblContent.TabIndex = 6;
        lblContent.Text = "İçerik";
        lblContent.TextAlign = ContentAlignment.TopLeft;
        // 
        // rtbContent
        // 
        rtbContent.Dock = DockStyle.Fill;
        rtbContent.Location = new Point(123, 123);
        rtbContent.Name = "rtbContent";
        rtbContent.Size = new Size(478, 99);
        rtbContent.TabIndex = 7;
        rtbContent.Text = "";
        // 
        // btnPublishAnnouncement
        // 
        btnPublishAnnouncement.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPublishAnnouncement.Location = new Point(456, 233);
        btnPublishAnnouncement.Margin = new Padding(3, 8, 3, 3);
        btnPublishAnnouncement.Name = "btnPublishAnnouncement";
        btnPublishAnnouncement.Size = new Size(145, 32);
        btnPublishAnnouncement.TabIndex = 8;
        btnPublishAnnouncement.Text = "Duyuru Yayınla";
        btnPublishAnnouncement.UseVisualStyleBackColor = true;
        btnPublishAnnouncement.Click += btnPublishAnnouncement_Click;
        // 
        // grpLogs
        // 
        grpLogs.Controls.Add(logLayout);
        grpLogs.Dock = DockStyle.Fill;
        grpLogs.Location = new Point(3, 318);
        grpLogs.Name = "grpLogs";
        grpLogs.Padding = new Padding(12);
        grpLogs.Size = new Size(628, 293);
        grpLogs.TabIndex = 1;
        grpLogs.TabStop = false;
        grpLogs.Text = "Bildirim Logları";
        // 
        // logLayout
        // 
        logLayout.ColumnCount = 1;
        logLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        logLayout.Controls.Add(rtbNotificationLog, 0, 0);
        logLayout.Controls.Add(btnClearLog, 0, 1);
        logLayout.Dock = DockStyle.Fill;
        logLayout.Location = new Point(12, 28);
        logLayout.Name = "logLayout";
        logLayout.RowCount = 2;
        logLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        logLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        logLayout.Size = new Size(604, 293);
        logLayout.TabIndex = 0;
        // 
        // rtbNotificationLog
        // 
        rtbNotificationLog.BackColor = Color.White;
        rtbNotificationLog.Dock = DockStyle.Fill;
        rtbNotificationLog.Location = new Point(3, 3);
        rtbNotificationLog.Name = "rtbNotificationLog";
        rtbNotificationLog.ReadOnly = true;
        rtbNotificationLog.Size = new Size(598, 243);
        rtbNotificationLog.TabIndex = 0;
        rtbNotificationLog.Text = "";
        // 
        // btnClearLog
        // 
        btnClearLog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClearLog.Location = new Point(473, 257);
        btnClearLog.Margin = new Padding(3, 8, 3, 3);
        btnClearLog.Name = "btnClearLog";
        btnClearLog.Size = new Size(128, 32);
        btnClearLog.TabIndex = 1;
        btnClearLog.Text = "Log Temizle";
        btnClearLog.UseVisualStyleBackColor = true;
        btnClearLog.Click += btnClearLog_Click;
        // 
        // btnLoadDemo
        // 
        btnLoadDemo.Location = new Point(787, 8);
        btnLoadDemo.Margin = new Padding(8, 0, 0, 0);
        btnLoadDemo.Name = "btnLoadDemo";
        btnLoadDemo.Size = new Size(145, 34);
        btnLoadDemo.TabIndex = 1;
        btnLoadDemo.Text = "Demo Senaryosunu Yükle";
        btnLoadDemo.UseVisualStyleBackColor = true;
        btnLoadDemo.Click += btnLoadDemo_Click;
        // 
        // btnClearForm
        // 
        btnClearForm.Location = new Point(940, 8);
        btnClearForm.Margin = new Padding(8, 0, 0, 0);
        btnClearForm.Name = "btnClearForm";
        btnClearForm.Size = new Size(130, 34);
        btnClearForm.TabIndex = 0;
        btnClearForm.Text = "Formu Temizle";
        btnClearForm.UseVisualStyleBackColor = true;
        btnClearForm.Click += btnClearForm_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1100, 700);
        Controls.Add(mainLayout);
        Font = new Font("Segoe UI", 10F);
        MinimumSize = new Size(1000, 650);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Akıllı Kampüs Duyuru ve Bildirim Yönetim Sistemi";
        mainLayout.ResumeLayout(false);
        contentLayout.ResumeLayout(false);
        leftLayout.ResumeLayout(false);
        rightLayout.ResumeLayout(false);
        commandPanel.ResumeLayout(false);
        grpAddUser.ResumeLayout(false);
        grpUsers.ResumeLayout(false);
        grpAnnouncement.ResumeLayout(false);
        grpLogs.ResumeLayout(false);
        addUserLayout.ResumeLayout(false);
        addUserLayout.PerformLayout();
        announcementLayout.ResumeLayout(false);
        announcementLayout.PerformLayout();
        logLayout.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
        ResumeLayout(false);
    }
}
