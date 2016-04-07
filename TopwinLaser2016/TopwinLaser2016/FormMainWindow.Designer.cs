namespace TopwinLaser2016
{
    partial class FormMainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.打印PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印预览VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.打开OToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.保存SToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.IDM_LASER_SWITCH = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ID_BUTTON_ZOOM_UP = new System.Windows.Forms.ToolStripButton();
            this.ID_BUTTON_ZOOM_DOWN = new System.Windows.Forms.ToolStripButton();
            this.ID_BUTTON_RESET = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.IDM_ARRAY = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.IDM_SELECT = new System.Windows.Forms.ToolStripButton();
            this.IDM_OFFSET = new System.Windows.Forms.ToolStripButton();
            this.ID_EDIT_DELETE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.IDM_SYS_OPTION_JIAGONG = new System.Windows.Forms.ToolStripButton();
            this.IDM_SYS_OPTION_DRAW = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.IDM_OBJ_GRID = new System.Windows.Forms.ToolStripButton();
            this.IDM_DRAW_GRID = new System.Windows.Forms.ToolStripButton();
            this.IDM_OBJ_CUT = new System.Windows.Forms.ToolStripButton();
            this.IDM_OBJ_DELETE_CUT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.IDM_HANDLOCATION_CAMERA_START = new System.Windows.Forms.ToolStripButton();
            this.IDM_AUTOLOCATION = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.IDM_POINT_LOCATION = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControlMachining = new TopwinLaser2016.UserControlMachining();
            this.userControlZMover = new TopwinLaser2016.UserControlZMover();
            this.userControlXYMover = new TopwinLaser2016.UserControlXYMover();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.IDM_PANE_OBJECT_PROPERTY = new System.Windows.Forms.ToolStripButton();
            this.IDM_MOVETO_ORIGIN = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_view = new System.Windows.Forms.TabPage();
            this.userControlGraphpaper = new TopwinLaser2016.UserControlGraphpaper();
            this.tabPage_ccd = new System.Windows.Forms.TabPage();
            this.cameraView1 = new CameraView.CameraView();
            this.tabPage_laser = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage_ESI = new System.Windows.Forms.TabPage();
            this.userControlLaser = new TopwinLaser2016.UserControlLaser();
            this.tabPage_SP = new System.Windows.Forms.TabPage();
            this.tabPage_Optowave = new System.Windows.Forms.TabPage();
            this.tabPage_Vgen = new System.Windows.Forms.TabPage();
            this.tabPage_stage = new System.Windows.Forms.TabPage();
            this.userControlStage = new TopwinLaser2016.UserControlStage();
            this.tabPage_io = new System.Windows.Forms.TabPage();
            this.userControlIO = new TopwinLaser2016.UserControlIO();
            this.tabPage_axis = new System.Windows.Forms.TabPage();
            this.userControlAxis = new TopwinLaser2016.UserControlAxis();
            this.tabPage_galvo = new System.Windows.Forms.TabPage();
            this.userControlGalvo = new TopwinLaser2016.UserControlGalvo();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_view.SuspendLayout();
            this.tabPage_ccd.SuspendLayout();
            this.tabPage_laser.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage_ESI.SuspendLayout();
            this.tabPage_stage.SuspendLayout();
            this.tabPage_io.SuspendLayout();
            this.tabPage_axis.SuspendLayout();
            this.tabPage_galvo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.工具TToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建NToolStripMenuItem,
            this.打开OToolStripMenuItem,
            this.toolStripSeparator,
            this.保存SToolStripMenuItem,
            this.另存为AToolStripMenuItem,
            this.toolStripSeparator1,
            this.打印PToolStripMenuItem,
            this.打印预览VToolStripMenuItem,
            this.toolStripSeparator2,
            this.退出XToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 新建NToolStripMenuItem
            // 
            this.新建NToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("新建NToolStripMenuItem.Image")));
            this.新建NToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新建NToolStripMenuItem.Name = "新建NToolStripMenuItem";
            this.新建NToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.新建NToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.新建NToolStripMenuItem.Text = "新建(&N)";
            // 
            // 打开OToolStripMenuItem
            // 
            this.打开OToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打开OToolStripMenuItem.Image")));
            this.打开OToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.打开OToolStripMenuItem.Text = "打开(&O)";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(162, 6);
            // 
            // 保存SToolStripMenuItem
            // 
            this.保存SToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("保存SToolStripMenuItem.Image")));
            this.保存SToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem";
            this.保存SToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存SToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.保存SToolStripMenuItem.Text = "保存(&S)";
            // 
            // 另存为AToolStripMenuItem
            // 
            this.另存为AToolStripMenuItem.Name = "另存为AToolStripMenuItem";
            this.另存为AToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.另存为AToolStripMenuItem.Text = "另存为(&A)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // 打印PToolStripMenuItem
            // 
            this.打印PToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打印PToolStripMenuItem.Image")));
            this.打印PToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打印PToolStripMenuItem.Name = "打印PToolStripMenuItem";
            this.打印PToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.打印PToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.打印PToolStripMenuItem.Text = "打印(&P)";
            // 
            // 打印预览VToolStripMenuItem
            // 
            this.打印预览VToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("打印预览VToolStripMenuItem.Image")));
            this.打印预览VToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打印预览VToolStripMenuItem.Name = "打印预览VToolStripMenuItem";
            this.打印预览VToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.打印预览VToolStripMenuItem.Text = "打印预览(&V)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.退出XToolStripMenuItem.Text = "退出(&X)";
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自定义CToolStripMenuItem,
            this.选项OToolStripMenuItem});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            // 
            // 自定义CToolStripMenuItem
            // 
            this.自定义CToolStripMenuItem.Name = "自定义CToolStripMenuItem";
            this.自定义CToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.自定义CToolStripMenuItem.Text = "自定义(&C)";
            // 
            // 选项OToolStripMenuItem
            // 
            this.选项OToolStripMenuItem.Name = "选项OToolStripMenuItem";
            this.选项OToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.选项OToolStripMenuItem.Text = "选项(&O)";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于AToolStripMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.关于AToolStripMenuItem.Text = "关于(&A)...";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel7});
            this.statusStrip1.Location = new System.Drawing.Point(0, 607);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel1.Text = "进度";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel2.Text = "图形坐标";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(134, 17);
            this.toolStripStatusLabel3.Text = "X:AAA.AAA,Y:AAA.AAA";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel4.Text = "加工时间";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(92, 17);
            this.toolStripStatusLabel5.Text = "AA时AA分AA秒";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel6.Text = "重复加工次数";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(36, 17);
            this.toolStripStatusLabel7.Text = "AA次";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开OToolStripButton,
            this.保存SToolStripButton,
            this.toolStripSeparator3,
            this.IDM_LASER_SWITCH,
            this.toolStripSeparator4,
            this.ID_BUTTON_ZOOM_UP,
            this.ID_BUTTON_ZOOM_DOWN,
            this.ID_BUTTON_RESET,
            this.toolStripSeparator6,
            this.IDM_ARRAY,
            this.toolStripSeparator5,
            this.IDM_SELECT,
            this.IDM_OFFSET,
            this.ID_EDIT_DELETE,
            this.toolStripSeparator7,
            this.IDM_SYS_OPTION_JIAGONG,
            this.IDM_SYS_OPTION_DRAW,
            this.toolStripSeparator8,
            this.IDM_OBJ_GRID,
            this.IDM_DRAW_GRID,
            this.IDM_OBJ_CUT,
            this.IDM_OBJ_DELETE_CUT,
            this.toolStripSeparator9,
            this.IDM_HANDLOCATION_CAMERA_START,
            this.IDM_AUTOLOCATION,
            this.toolStripSeparator10,
            this.IDM_POINT_LOCATION});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // 打开OToolStripButton
            // 
            this.打开OToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.打开OToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("打开OToolStripButton.Image")));
            this.打开OToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开OToolStripButton.Name = "打开OToolStripButton";
            this.打开OToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.打开OToolStripButton.Text = "打开(&O)";
            this.打开OToolStripButton.ToolTipText = "打开一个现有文档";
            this.打开OToolStripButton.Click += new System.EventHandler(this.打开OToolStripButton_Click);
            // 
            // 保存SToolStripButton
            // 
            this.保存SToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.保存SToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("保存SToolStripButton.Image")));
            this.保存SToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存SToolStripButton.Name = "保存SToolStripButton";
            this.保存SToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.保存SToolStripButton.Text = "保存(&S)";
            this.保存SToolStripButton.ToolTipText = "保存活动文档";
            this.保存SToolStripButton.Click += new System.EventHandler(this.保存SToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // IDM_LASER_SWITCH
            // 
            this.IDM_LASER_SWITCH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IDM_LASER_SWITCH.Image = ((System.Drawing.Image)(resources.GetObject("IDM_LASER_SWITCH.Image")));
            this.IDM_LASER_SWITCH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDM_LASER_SWITCH.Name = "IDM_LASER_SWITCH";
            this.IDM_LASER_SWITCH.Size = new System.Drawing.Size(23, 22);
            this.IDM_LASER_SWITCH.Text = "激光开关";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // ID_BUTTON_ZOOM_UP
            // 
            this.ID_BUTTON_ZOOM_UP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ID_BUTTON_ZOOM_UP.Image = ((System.Drawing.Image)(resources.GetObject("ID_BUTTON_ZOOM_UP.Image")));
            this.ID_BUTTON_ZOOM_UP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ID_BUTTON_ZOOM_UP.Name = "ID_BUTTON_ZOOM_UP";
            this.ID_BUTTON_ZOOM_UP.Size = new System.Drawing.Size(23, 22);
            this.ID_BUTTON_ZOOM_UP.Text = "放大当前对象";
            // 
            // ID_BUTTON_ZOOM_DOWN
            // 
            this.ID_BUTTON_ZOOM_DOWN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ID_BUTTON_ZOOM_DOWN.Image = ((System.Drawing.Image)(resources.GetObject("ID_BUTTON_ZOOM_DOWN.Image")));
            this.ID_BUTTON_ZOOM_DOWN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ID_BUTTON_ZOOM_DOWN.Name = "ID_BUTTON_ZOOM_DOWN";
            this.ID_BUTTON_ZOOM_DOWN.Size = new System.Drawing.Size(23, 22);
            this.ID_BUTTON_ZOOM_DOWN.Text = "缩小当前对象";
            // 
            // ID_BUTTON_RESET
            // 
            this.ID_BUTTON_RESET.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ID_BUTTON_RESET.Image = ((System.Drawing.Image)(resources.GetObject("ID_BUTTON_RESET.Image")));
            this.ID_BUTTON_RESET.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ID_BUTTON_RESET.Name = "ID_BUTTON_RESET";
            this.ID_BUTTON_RESET.Size = new System.Drawing.Size(23, 22);
            this.ID_BUTTON_RESET.Text = "合理显示当前对象";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // IDM_ARRAY
            // 
            this.IDM_ARRAY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IDM_ARRAY.Image = ((System.Drawing.Image)(resources.GetObject("IDM_ARRAY.Image")));
            this.IDM_ARRAY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDM_ARRAY.Name = "IDM_ARRAY";
            this.IDM_ARRAY.Size = new System.Drawing.Size(23, 22);
            this.IDM_ARRAY.Text = "阵列加工图形";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // IDM_SELECT
            // 
            this.IDM_SELECT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IDM_SELECT.Image = ((System.Drawing.Image)(resources.GetObject("IDM_SELECT.Image")));
            this.IDM_SELECT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDM_SELECT.Name = "IDM_SELECT";
            this.IDM_SELECT.Size = new System.Drawing.Size(23, 22);
            this.IDM_SELECT.Text = "选中当前对象";
            // 
            // IDM_OFFSET
            // 
            this.IDM_OFFSET.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IDM_OFFSET.Image = ((System.Drawing.Image)(resources.GetObject("IDM_OFFSET.Image")));
            this.IDM_OFFSET.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDM_OFFSET.Name = "IDM_OFFSET";
            this.IDM_OFFSET.Size = new System.Drawing.Size(23, 22);
            this.IDM_OFFSET.Text = "平移选中对象";
            // 
            // ID_EDIT_DELETE
            // 
            this.ID_EDIT_DELETE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ID_EDIT_DELETE.Image = ((System.Drawing.Image)(resources.GetObject("ID_EDIT_DELETE.Image")));
            this.ID_EDIT_DELETE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ID_EDIT_DELETE.Name = "ID_EDIT_DELETE";
            this.ID_EDIT_DELETE.Size = new System.Drawing.Size(23, 22);
            this.ID_EDIT_DELETE.Text = "删除";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // IDM_SYS_OPTION_JIAGONG
            // 
            this.IDM_SYS_OPTION_JIAGONG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IDM_SYS_OPTION_JIAGONG.Image = ((System.Drawing.Image)(resources.GetObject("IDM_SYS_OPTION_JIAGONG.Image")));
            this.IDM_SYS_OPTION_JIAGONG.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDM_SYS_OPTION_JIAGONG.Name = "IDM_SYS_OPTION_JIAGONG";
            this.IDM_SYS_OPTION_JIAGONG.Size = new System.Drawing.Size(23, 22);
            this.IDM_SYS_OPTION_JIAGONG.Text = "加工设置";
            // 
            // IDM_SYS_OPTION_DRAW
            // 
            this.IDM_SYS_OPTION_DRAW.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IDM_SYS_OPTION_DRAW.Image = ((System.Drawing.Image)(resources.GetObject("IDM_SYS_OPTION_DRAW.Image")));
            this.IDM_SYS_OPTION_DRAW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDM_SYS_OPTION_DRAW.Name = "IDM_SYS_OPTION_DRAW";
            this.IDM_SYS_OPTION_DRAW.Size = new System.Drawing.Size(23, 22);
            this.IDM_SYS_OPTION_DRAW.Text = "分格设置";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // IDM_OBJ_GRID
            // 
            this.IDM_OBJ_GRID.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IDM_OBJ_GRID.Image = ((System.Drawing.Image)(resources.GetObject("IDM_OBJ_GRID.Image")));
            this.IDM_OBJ_GRID.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDM_OBJ_GRID.Name = "IDM_OBJ_GRID";
            this.IDM_OBJ_GRID.Size = new System.Drawing.Size(23, 22);
            this.IDM_OBJ_GRID.Text = "分格离散";
            // 
            // IDM_DRAW_GRID
            // 
            this.IDM_DRAW_GRID.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IDM_DRAW_GRID.Image = ((System.Drawing.Image)(resources.GetObject("IDM_DRAW_GRID.Image")));
            this.IDM_DRAW_GRID.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDM_DRAW_GRID.Name = "IDM_DRAW_GRID";
            this.IDM_DRAW_GRID.Size = new System.Drawing.Size(23, 22);
            this.IDM_DRAW_GRID.Text = "选中区域加工";
            // 
            // IDM_OBJ_CUT
            // 
            this.IDM_OBJ_CUT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IDM_OBJ_CUT.Image = ((System.Drawing.Image)(resources.GetObject("IDM_OBJ_CUT.Image")));
            this.IDM_OBJ_CUT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDM_OBJ_CUT.Name = "IDM_OBJ_CUT";
            this.IDM_OBJ_CUT.Size = new System.Drawing.Size(23, 22);
            this.IDM_OBJ_CUT.Text = "离散指定对象";
            // 
            // IDM_OBJ_DELETE_CUT
            // 
            this.IDM_OBJ_DELETE_CUT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IDM_OBJ_DELETE_CUT.Image = ((System.Drawing.Image)(resources.GetObject("IDM_OBJ_DELETE_CUT.Image")));
            this.IDM_OBJ_DELETE_CUT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDM_OBJ_DELETE_CUT.Name = "IDM_OBJ_DELETE_CUT";
            this.IDM_OBJ_DELETE_CUT.Size = new System.Drawing.Size(23, 22);
            this.IDM_OBJ_DELETE_CUT.Text = "删除离散对象";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // IDM_HANDLOCATION_CAMERA_START
            // 
            this.IDM_HANDLOCATION_CAMERA_START.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IDM_HANDLOCATION_CAMERA_START.Image = ((System.Drawing.Image)(resources.GetObject("IDM_HANDLOCATION_CAMERA_START.Image")));
            this.IDM_HANDLOCATION_CAMERA_START.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDM_HANDLOCATION_CAMERA_START.Name = "IDM_HANDLOCATION_CAMERA_START";
            this.IDM_HANDLOCATION_CAMERA_START.Size = new System.Drawing.Size(23, 22);
            this.IDM_HANDLOCATION_CAMERA_START.Text = "手动定位";
            // 
            // IDM_AUTOLOCATION
            // 
            this.IDM_AUTOLOCATION.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IDM_AUTOLOCATION.Image = ((System.Drawing.Image)(resources.GetObject("IDM_AUTOLOCATION.Image")));
            this.IDM_AUTOLOCATION.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDM_AUTOLOCATION.Name = "IDM_AUTOLOCATION";
            this.IDM_AUTOLOCATION.Size = new System.Drawing.Size(23, 22);
            this.IDM_AUTOLOCATION.Text = "自动定位";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // IDM_POINT_LOCATION
            // 
            this.IDM_POINT_LOCATION.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IDM_POINT_LOCATION.Image = ((System.Drawing.Image)(resources.GetObject("IDM_POINT_LOCATION.Image")));
            this.IDM_POINT_LOCATION.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDM_POINT_LOCATION.Name = "IDM_POINT_LOCATION";
            this.IDM_POINT_LOCATION.Size = new System.Drawing.Size(23, 22);
            this.IDM_POINT_LOCATION.Text = "定位";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userControlMachining);
            this.panel1.Controls.Add(this.userControlZMover);
            this.panel1.Controls.Add(this.userControlXYMover);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 582);
            this.panel1.TabIndex = 3;
            // 
            // userControlMachining
            // 
            this.userControlMachining.Location = new System.Drawing.Point(3, 246);
            this.userControlMachining.Name = "userControlMachining";
            this.userControlMachining.Size = new System.Drawing.Size(250, 120);
            this.userControlMachining.TabIndex = 0;
            // 
            // userControlZMover
            // 
            this.userControlZMover.Location = new System.Drawing.Point(3, 187);
            this.userControlZMover.Name = "userControlZMover";
            this.userControlZMover.Size = new System.Drawing.Size(250, 62);
            this.userControlZMover.TabIndex = 0;
            // 
            // userControlXYMover
            // 
            this.userControlXYMover.CurrentX = 0D;
            this.userControlXYMover.CurrentY = 0D;
            this.userControlXYMover.Location = new System.Drawing.Point(3, 3);
            this.userControlXYMover.Name = "userControlXYMover";
            this.userControlXYMover.Size = new System.Drawing.Size(250, 194);
            this.userControlXYMover.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_PANE_OBJECT_PROPERTY,
            this.IDM_MOVETO_ORIGIN});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(919, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(58, 25);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // IDM_PANE_OBJECT_PROPERTY
            // 
            this.IDM_PANE_OBJECT_PROPERTY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IDM_PANE_OBJECT_PROPERTY.Image = ((System.Drawing.Image)(resources.GetObject("IDM_PANE_OBJECT_PROPERTY.Image")));
            this.IDM_PANE_OBJECT_PROPERTY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDM_PANE_OBJECT_PROPERTY.Name = "IDM_PANE_OBJECT_PROPERTY";
            this.IDM_PANE_OBJECT_PROPERTY.Size = new System.Drawing.Size(23, 22);
            this.IDM_PANE_OBJECT_PROPERTY.Text = "toolStripButton1";
            // 
            // IDM_MOVETO_ORIGIN
            // 
            this.IDM_MOVETO_ORIGIN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IDM_MOVETO_ORIGIN.Image = ((System.Drawing.Image)(resources.GetObject("IDM_MOVETO_ORIGIN.Image")));
            this.IDM_MOVETO_ORIGIN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IDM_MOVETO_ORIGIN.Name = "IDM_MOVETO_ORIGIN";
            this.IDM_MOVETO_ORIGIN.Size = new System.Drawing.Size(23, 22);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_view);
            this.tabControl1.Controls.Add(this.tabPage_ccd);
            this.tabControl1.Controls.Add(this.tabPage_laser);
            this.tabControl1.Controls.Add(this.tabPage_stage);
            this.tabControl1.Controls.Add(this.tabPage_io);
            this.tabControl1.Controls.Add(this.tabPage_axis);
            this.tabControl1.Controls.Add(this.tabPage_galvo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(255, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(753, 582);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage_view
            // 
            this.tabPage_view.Controls.Add(this.userControlGraphpaper);
            this.tabPage_view.Location = new System.Drawing.Point(4, 22);
            this.tabPage_view.Name = "tabPage_view";
            this.tabPage_view.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_view.Size = new System.Drawing.Size(745, 556);
            this.tabPage_view.TabIndex = 0;
            this.tabPage_view.Text = "图纸";
            this.tabPage_view.UseVisualStyleBackColor = true;
            // 
            // userControlGraphpaper
            // 
            this.userControlGraphpaper.Location = new System.Drawing.Point(3, 3);
            this.userControlGraphpaper.Name = "userControlGraphpaper";
            this.userControlGraphpaper.Size = new System.Drawing.Size(694, 540);
            this.userControlGraphpaper.TabIndex = 0;
            // 
            // tabPage_ccd
            // 
            this.tabPage_ccd.Controls.Add(this.cameraView1);
            this.tabPage_ccd.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ccd.Name = "tabPage_ccd";
            this.tabPage_ccd.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ccd.Size = new System.Drawing.Size(745, 556);
            this.tabPage_ccd.TabIndex = 1;
            this.tabPage_ccd.Text = "相机";
            this.tabPage_ccd.UseVisualStyleBackColor = true;
            // 
            // cameraView1
            // 
            this.cameraView1.AutoScroll = true;
            this.cameraView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraView1.Location = new System.Drawing.Point(3, 3);
            this.cameraView1.Name = "cameraView1";
            this.cameraView1.Size = new System.Drawing.Size(739, 550);
            this.cameraView1.TabIndex = 0;
            // 
            // tabPage_laser
            // 
            this.tabPage_laser.Controls.Add(this.tabControl2);
            this.tabPage_laser.Location = new System.Drawing.Point(4, 22);
            this.tabPage_laser.Name = "tabPage_laser";
            this.tabPage_laser.Size = new System.Drawing.Size(745, 556);
            this.tabPage_laser.TabIndex = 2;
            this.tabPage_laser.Text = "激光器";
            this.tabPage_laser.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage_ESI);
            this.tabControl2.Controls.Add(this.tabPage_SP);
            this.tabControl2.Controls.Add(this.tabPage_Optowave);
            this.tabControl2.Controls.Add(this.tabPage_Vgen);
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(636, 543);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage_ESI
            // 
            this.tabPage_ESI.Controls.Add(this.userControlLaser);
            this.tabPage_ESI.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ESI.Name = "tabPage_ESI";
            this.tabPage_ESI.Size = new System.Drawing.Size(628, 517);
            this.tabPage_ESI.TabIndex = 3;
            this.tabPage_ESI.Text = "ESI";
            this.tabPage_ESI.UseVisualStyleBackColor = true;
            // 
            // userControlLaser
            // 
            this.userControlLaser.Location = new System.Drawing.Point(3, 3);
            this.userControlLaser.Name = "userControlLaser";
            this.userControlLaser.Size = new System.Drawing.Size(366, 388);
            this.userControlLaser.TabIndex = 0;
            // 
            // tabPage_SP
            // 
            this.tabPage_SP.Location = new System.Drawing.Point(4, 22);
            this.tabPage_SP.Name = "tabPage_SP";
            this.tabPage_SP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SP.Size = new System.Drawing.Size(628, 517);
            this.tabPage_SP.TabIndex = 0;
            this.tabPage_SP.Text = "SP";
            this.tabPage_SP.UseVisualStyleBackColor = true;
            // 
            // tabPage_Optowave
            // 
            this.tabPage_Optowave.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Optowave.Name = "tabPage_Optowave";
            this.tabPage_Optowave.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Optowave.Size = new System.Drawing.Size(628, 517);
            this.tabPage_Optowave.TabIndex = 1;
            this.tabPage_Optowave.Text = "Optowave";
            this.tabPage_Optowave.UseVisualStyleBackColor = true;
            // 
            // tabPage_Vgen
            // 
            this.tabPage_Vgen.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Vgen.Name = "tabPage_Vgen";
            this.tabPage_Vgen.Size = new System.Drawing.Size(628, 517);
            this.tabPage_Vgen.TabIndex = 2;
            this.tabPage_Vgen.Text = "Vgen";
            this.tabPage_Vgen.UseVisualStyleBackColor = true;
            // 
            // tabPage_stage
            // 
            this.tabPage_stage.Controls.Add(this.userControlStage);
            this.tabPage_stage.Location = new System.Drawing.Point(4, 22);
            this.tabPage_stage.Name = "tabPage_stage";
            this.tabPage_stage.Size = new System.Drawing.Size(745, 556);
            this.tabPage_stage.TabIndex = 6;
            this.tabPage_stage.Text = "平台";
            this.tabPage_stage.UseVisualStyleBackColor = true;
            // 
            // userControlStage
            // 
            this.userControlStage.Location = new System.Drawing.Point(3, 3);
            this.userControlStage.Name = "userControlStage";
            this.userControlStage.Size = new System.Drawing.Size(639, 379);
            this.userControlStage.TabIndex = 0;
            // 
            // tabPage_io
            // 
            this.tabPage_io.Controls.Add(this.userControlIO);
            this.tabPage_io.Location = new System.Drawing.Point(4, 22);
            this.tabPage_io.Name = "tabPage_io";
            this.tabPage_io.Size = new System.Drawing.Size(745, 556);
            this.tabPage_io.TabIndex = 3;
            this.tabPage_io.Text = "IO端口";
            this.tabPage_io.UseVisualStyleBackColor = true;
            // 
            // userControlIO
            // 
            this.userControlIO.Location = new System.Drawing.Point(3, 3);
            this.userControlIO.Name = "userControlIO";
            this.userControlIO.Size = new System.Drawing.Size(539, 550);
            this.userControlIO.TabIndex = 0;
            // 
            // tabPage_axis
            // 
            this.tabPage_axis.Controls.Add(this.userControlAxis);
            this.tabPage_axis.Location = new System.Drawing.Point(4, 22);
            this.tabPage_axis.Name = "tabPage_axis";
            this.tabPage_axis.Size = new System.Drawing.Size(745, 556);
            this.tabPage_axis.TabIndex = 4;
            this.tabPage_axis.Text = "轴";
            this.tabPage_axis.UseVisualStyleBackColor = true;
            // 
            // userControlAxis
            // 
            this.userControlAxis.Location = new System.Drawing.Point(3, 3);
            this.userControlAxis.Name = "userControlAxis";
            this.userControlAxis.Size = new System.Drawing.Size(308, 314);
            this.userControlAxis.TabIndex = 0;
            // 
            // tabPage_galvo
            // 
            this.tabPage_galvo.Controls.Add(this.userControlGalvo);
            this.tabPage_galvo.Location = new System.Drawing.Point(4, 22);
            this.tabPage_galvo.Name = "tabPage_galvo";
            this.tabPage_galvo.Size = new System.Drawing.Size(745, 556);
            this.tabPage_galvo.TabIndex = 5;
            this.tabPage_galvo.Text = "振镜";
            this.tabPage_galvo.UseVisualStyleBackColor = true;
            // 
            // userControlGalvo
            // 
            this.userControlGalvo.Location = new System.Drawing.Point(3, 3);
            this.userControlGalvo.Name = "userControlGalvo";
            this.userControlGalvo.Size = new System.Drawing.Size(496, 289);
            this.userControlGalvo.TabIndex = 0;
            // 
            // FormMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 629);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMainWindow";
            this.Text = "TopwinLaser2016";
            this.Load += new System.EventHandler(this.FormMainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_view.ResumeLayout(false);
            this.tabPage_ccd.ResumeLayout(false);
            this.tabPage_laser.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage_ESI.ResumeLayout(false);
            this.tabPage_stage.ResumeLayout(false);
            this.tabPage_io.ResumeLayout(false);
            this.tabPage_axis.ResumeLayout(false);
            this.tabPage_galvo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为AToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 打印PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印预览VToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自定义CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选项OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 打开OToolStripButton;
        private System.Windows.Forms.ToolStripButton 保存SToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton IDM_LASER_SWITCH;
        private System.Windows.Forms.ToolStripButton ID_BUTTON_ZOOM_UP;
        private System.Windows.Forms.ToolStripButton ID_BUTTON_ZOOM_DOWN;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton ID_BUTTON_RESET;
        private System.Windows.Forms.ToolStripButton IDM_ARRAY;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton IDM_SELECT;
        private System.Windows.Forms.ToolStripButton IDM_OFFSET;
        private System.Windows.Forms.ToolStripButton ID_EDIT_DELETE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton IDM_SYS_OPTION_JIAGONG;
        private System.Windows.Forms.ToolStripButton IDM_SYS_OPTION_DRAW;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton IDM_OBJ_GRID;
        private System.Windows.Forms.ToolStripButton IDM_DRAW_GRID;
        private System.Windows.Forms.ToolStripButton IDM_OBJ_CUT;
        private System.Windows.Forms.ToolStripButton IDM_OBJ_DELETE_CUT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton IDM_HANDLOCATION_CAMERA_START;
        private System.Windows.Forms.ToolStripButton IDM_AUTOLOCATION;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton IDM_POINT_LOCATION;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton IDM_PANE_OBJECT_PROPERTY;
        private System.Windows.Forms.ToolStripButton IDM_MOVETO_ORIGIN;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_view;
        private System.Windows.Forms.TabPage tabPage_ccd;
        private System.Windows.Forms.TabPage tabPage_laser;
        private System.Windows.Forms.TabPage tabPage_stage;
        private System.Windows.Forms.TabPage tabPage_io;
        private System.Windows.Forms.TabPage tabPage_axis;
        private System.Windows.Forms.TabPage tabPage_galvo;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage_ESI;
        private System.Windows.Forms.TabPage tabPage_SP;
        private System.Windows.Forms.TabPage tabPage_Optowave;
        private System.Windows.Forms.TabPage tabPage_Vgen;
        private UserControlZMover userControlZMover;
        private UserControlXYMover userControlXYMover;
        private UserControlMachining userControlMachining;
        //private UserControlTasks userControlTasks;
        //private UserControlDataRecorder userControlDataRecorder;
        private UserControlLaser userControlLaser;
        private UserControlStage userControlStage;
        private UserControlIO userControlIO;
        private UserControlAxis userControlAxis;
        private UserControlGalvo userControlGalvo;
        private UserControlGraphpaper userControlGraphpaper;
        private CameraView.CameraView cameraView1;
    }
}

