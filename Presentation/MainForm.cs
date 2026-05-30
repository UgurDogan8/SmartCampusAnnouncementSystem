using SmartCampusAnnouncementSystem.Application.Services;
using SmartCampusAnnouncementSystem.Infrastructure.Data;
using SmartCampusAnnouncementSystem.Infrastructure.Singleton;

namespace SmartCampusAnnouncementSystem.Presentation;

public partial class MainForm : Form
{
    private readonly InMemoryDataStore _dataStore;
    private readonly UserService _userService;
    private readonly AnnouncementService _announcementService;
    private bool _demoLoaded = false;

    public MainForm()
    {
        InitializeComponent();
        dgvUsers.CellContentClick += dgvUsers_CellContentClick;

        _dataStore = new InMemoryDataStore();
        _userService = new UserService(_dataStore);
        _announcementService = new AnnouncementService(_dataStore);

        InitializeComboBoxes();
        ConfigureLogger();
        RefreshUsersGrid();
    }

    private void btnAddUser_Click(object? sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                ShowWarning("Ad Soyad alanı boş olamaz.");
                return;
            }

            if (cmbUserType.SelectedItem is null)
            {
                ShowWarning("Kullanıcı tipi seçilmelidir.");
                return;
            }

            if (cmbNotificationPreference.SelectedItem is null)
            {
                ShowWarning("Bildirim tercihi seçilmelidir.");
                return;
            }

            var fullName = txtFullName.Text.Trim();
            var userType = cmbUserType.SelectedItem.ToString() ?? string.Empty;
            var notificationPreference = cmbNotificationPreference.SelectedItem.ToString() ?? string.Empty;
            var userCountBeforeAdd = _userService.GetAllUsers().Count;

            _userService.CreateUser(userType, fullName, notificationPreference);
            RefreshUsersGrid();

            if (_userService.GetAllUsers().Count == userCountBeforeAdd)
            {
                AppendLog($"{fullName} adlı {userType} zaten kayıtlı olduğu için tekrar eklenmedi.");
                ShowInformation("Bu kullanıcı zaten kayıtlı.");
                return;
            }

            AppendLog("Kullanıcı başarıyla eklendi.");
            txtFullName.Clear();
            txtFullName.Focus();
        }
        catch (Exception exception)
        {
            ShowError($"Kullanıcı eklenirken hata oluştu: {exception.Message}");
        }
    }

    private void btnPublishAnnouncement_Click(object? sender, EventArgs e)
    {
        try
        {
            if (cmbAnnouncementType.SelectedItem is null)
            {
                ShowWarning("Duyuru tipi seçilmelidir.");
                return;
            }

            if (cmbTargetUserType.SelectedItem is null)
            {
                ShowWarning("Hedef kullanıcı seçilmelidir.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                ShowWarning("Başlık alanı boş olamaz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(rtbContent.Text))
            {
                ShowWarning("İçerik alanı boş olamaz.");
                return;
            }

            if (_userService.GetAllUsers().Count == 0)
            {
                ShowWarning("Duyuru yayınlamadan önce en az bir kullanıcı eklemelisiniz.");
                return;
            }

            var announcementType = cmbAnnouncementType.SelectedItem.ToString() ?? string.Empty;
            var targetUserType = cmbTargetUserType.SelectedItem.ToString() ?? string.Empty;
            var title = txtTitle.Text.Trim();
            var content = rtbContent.Text.Trim();

            if (!HasUsersForTarget(targetUserType))
            {
                ShowWarning("Seçilen hedef kullanıcı tipi için kayıtlı kullanıcı bulunmuyor.");
                return;
            }

            _announcementService.CreateAndPublishAnnouncement(announcementType, title, content, targetUserType);

            AppendLog("Duyuru başarıyla yayınlandı.");
            txtTitle.Clear();
            rtbContent.Clear();
            txtTitle.Focus();
        }
        catch (Exception exception)
        {
            ShowError($"Duyuru yayınlanırken hata oluştu: {exception.Message}");
        }
    }

    private void btnLoadDemo_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_demoLoaded)
            {
                ShowInformation("Demo senaryosu zaten yüklendi.");
                return;
            }

            _userService.CreateUser("Öğrenci", "Ahmet Yılmaz", "E-posta");
            _userService.CreateUser("Öğrenci", "Zeynep Kaya", "Mobil");
            _userService.CreateUser("Öğretmen", "Dr. Ayşe Demir", "SMS");

            _announcementService.CreateAndPublishAnnouncement(
                "Sınav",
                "Veri Yapıları Final Sınavı",
                "Final sınavı 10 Haziran saat 14.00'e alınmıştır.",
                "Öğrenci");

            _announcementService.CreateAndPublishAnnouncement(
                "Etkinlik",
                "Yapay Zeka Semineri",
                "Yapay zeka semineri konferans salonunda saat 13.00'te yapılacaktır.",
                "Herkes");

            _demoLoaded = true;
            RefreshUsersGrid();
            AppendLog("Demo senaryosu başarıyla tamamlandı.");
        }
        catch (Exception exception)
        {
            ShowError($"Demo senaryosu yüklenirken hata oluştu: {exception.Message}");
        }
    }

    private void btnClearLog_Click(object? sender, EventArgs e)
    {
        rtbNotificationLog.Clear();
    }

    private void btnClearForm_Click(object? sender, EventArgs e)
    {
        txtFullName.Clear();
        txtTitle.Clear();
        rtbContent.Clear();
        SetDefaultComboBoxSelections();
        txtFullName.Focus();
    }

    private void dgvUsers_CellContentClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvUsers.Columns[e.ColumnIndex].Name != "DeleteUser")
        {
            return;
        }

        var fullName = Convert.ToString(dgvUsers.Rows[e.RowIndex].Cells["FullName"].Value) ?? string.Empty;
        var userType = Convert.ToString(dgvUsers.Rows[e.RowIndex].Cells["UserType"].Value) ?? string.Empty;

        if (!ConfirmUserDelete(fullName, userType))
        {
            return;
        }

        try
        {
            if (_userService.DeleteUser(fullName, userType))
            {
                RefreshUsersGrid();
                AppendLog($"{fullName} adlı {userType} kullanıcı silindi.");
                return;
            }

            ShowInformation("Silinecek kullanıcı bulunamadı.");
        }
        catch (Exception exception)
        {
            ShowError($"Kullanıcı silinirken hata oluştu: {exception.Message}");
        }
    }

    private void InitializeComboBoxes()
    {
        cmbUserType.Items.Clear();
        cmbUserType.Items.AddRange(["Öğrenci", "Öğretmen"]);

        cmbNotificationPreference.Items.Clear();
        cmbNotificationPreference.Items.AddRange(["E-posta", "SMS", "Mobil"]);

        cmbAnnouncementType.Items.Clear();
        cmbAnnouncementType.Items.AddRange(["Sınav", "Etkinlik", "Yemekhane", "Kütüphane"]);

        cmbTargetUserType.Items.Clear();
        cmbTargetUserType.Items.AddRange(["Herkes", "Öğrenci", "Öğretmen"]);

        SetDefaultComboBoxSelections();
    }

    private void ConfigureLogger()
    {
        NotificationCenter.Instance.SetLogger(AppendLog);
    }

    private void RefreshUsersGrid()
    {
        EnsureUsersGridColumns();
        dgvUsers.Rows.Clear();

        foreach (var user in _userService.GetAllUsers())
        {
            dgvUsers.Rows.Add(user.FullName, user.UserType, user.PreferredNotificationType);
        }
    }

    private void SetDefaultComboBoxSelections()
    {
        cmbUserType.SelectedIndex = cmbUserType.Items.Count > 0 ? 0 : -1;
        cmbNotificationPreference.SelectedIndex = cmbNotificationPreference.Items.Count > 0 ? 0 : -1;
        cmbAnnouncementType.SelectedIndex = cmbAnnouncementType.Items.Count > 0 ? 0 : -1;
        cmbTargetUserType.SelectedIndex = cmbTargetUserType.Items.Count > 0 ? 0 : -1;
    }

    private bool HasUsersForTarget(string targetUserType)
    {
        return _userService.GetAllUsers().Any(user =>
            string.Equals(targetUserType, "Herkes", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(user.UserType, targetUserType, StringComparison.OrdinalIgnoreCase));
    }

    private void EnsureUsersGridColumns()
    {
        if (dgvUsers.Columns.Count > 0)
        {
            return;
        }

        dgvUsers.Columns.Add("FullName", "Ad Soyad");
        dgvUsers.Columns.Add("UserType", "Kullanıcı Tipi");
        dgvUsers.Columns.Add("PreferredNotificationType", "Bildirim Tercihi");

        var deleteColumn = new DataGridViewButtonColumn
        {
            Name = "DeleteUser",
            HeaderText = string.Empty,
            Text = "✕",
            ToolTipText = "Kullanıcıyı sil",
            UseColumnTextForButtonValue = true,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            Width = 42,
            FlatStyle = FlatStyle.Flat
        };

        dgvUsers.Columns.Add(deleteColumn);
    }

    private void AppendLog(string message)
    {
        if (rtbNotificationLog.InvokeRequired)
        {
            rtbNotificationLog.BeginInvoke(() => AppendLog(message));
            return;
        }

        rtbNotificationLog.AppendText(message + Environment.NewLine);
        rtbNotificationLog.ScrollToCaret();
    }

    private void ShowWarning(string message)
    {
        MessageBox.Show(
            this,
            message,
            "Uyarı",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
    }

    private bool ConfirmUserDelete(string fullName, string userType)
    {
        var result = MessageBox.Show(
            this,
            $"{fullName} adlı {userType} kullanıcıyı silmek istiyor musunuz?",
            "Kullanıcı Silme Onayı",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2);

        return result == DialogResult.Yes;
    }

    private void ShowInformation(string message)
    {
        MessageBox.Show(
            this,
            message,
            "Bilgi",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void ShowError(string message)
    {
        MessageBox.Show(
            this,
            message,
            "Hata",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}
