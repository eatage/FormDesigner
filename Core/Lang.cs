using System;
using System.Collections.Generic;

namespace FormDesinger
{
    /// <summary>
    /// 界面语言
    /// </summary>
    public enum Language
    {
        Chinese,
        English,
        German
    }

    /// <summary>
    /// 界面多语言
    /// <para>以中文原文作为键,查找对应的英文/德文翻译,找不到时返回原文</para>
    /// </summary>
    public static class Lang
    {
        private static Language _current = Language.Chinese;
        private static readonly Dictionary<string, string[]> _texts = new Dictionary<string, string[]>();

        static Lang()
        {
            //主窗体菜单
            Add("菜单", "Menu", "Menü");
            Add("新建", "New", "Neu");
            Add("打开", "Open", "Öffnen");
            Add("保存", "Save", "Speichern");
            Add("退出", "Exit", "Beenden");
            Add("视图", "View", "Ansicht");
            Add("设计器最大化", "Maximize designer", "Designer maximieren");
            Add("还原", "Restore", "Wiederherstellen");
            Add("语言", "Language", "Sprache");

            //工具栏
            Add("微调", "Fine-tune", "Feinabstimmung");
            Add("对齐", "Align", "Ausrichten");
            Add("左对齐", "Align left", "Links ausrichten");
            Add("上对齐", "Align top", "Oben ausrichten");

            //工具箱
            Add("从程序集添加...", "Add from assembly...", "Aus Assembly hinzufügen...");
            Add("单击从.net程序集添加外部控件", "Click to add external controls from a .NET assembly", "Klicken, um externe Steuerelemente aus einer .NET-Assembly hinzuzufügen");
            Add("自定义控件", "Custom controls", "Eigene Elemente");
            Add("从.net程序集添加外部控件", "Add external controls from a .NET assembly", "Externe Steuerelemente aus einer .NET-Assembly hinzufügen");
            Add("所有Windows窗体", "All Windows Forms", "Windows Forms");
            Add("工具箱,将下列控件拖到设计器里可添加对应控件", "Toolbox: drag the controls below onto the designer to add them", "Werkzeugkasten: Steuerelemente in den Designer ziehen, um sie hinzuzufügen");
            Add("允许对控件集合分组", "Groups a collection of controls", "Ermöglicht das Gruppieren von Steuerelementen");
            Add("允许用户选择或清除关联选项", "Lets the user select or clear the associated option", "Ermöglicht dem Benutzer, die zugehörige Option zu aktivieren oder zu deaktivieren");
            Add("树形结构,显示可选择包含图像的标签项的分层集合", "Tree view: displays a hierarchical collection of labeled items, each optionally with an image", "Strukturansicht: zeigt eine hierarchische Sammlung beschrifteter Elemente, optional mit Bild");
            Add("显示操作进度的填充条", "Displays a bar that fills to indicate the progress of an operation", "Zeigt eine Leiste an, die den Fortschritt eines Vorgangs darstellt");
            Add("允许用户输入文本,并提供多行编辑及密码字符掩码功能", "Lets the user enter text, with multiline editing and password character masking", "Ermöglicht die Texteingabe, mit mehrzeiliger Bearbeitung und Kennwortmaskierung");
            Add("\n显示图片", "\nDisplays an image", "\nZeigt ein Bild an");
            Add("按钮,用户单击时引发事件", "Button: raises an event when the user clicks it", "Schaltfläche: löst ein Ereignis aus, wenn der Benutzer darauf klickt");
            Add("显示支持超链接的标签", "Displays a label that supports hyperlinks", "Zeigt eine Beschriftung mit Hyperlink-Unterstützung an");
            Add("当与其他单选按钮成对出现时,允许用户从一组选项中选择单个选项", "Used together with other radio buttons, lets the user pick a single option from a group", "Ermöglicht zusammen mit anderen Optionsfeldern die Auswahl einer einzelnen Option aus einer Gruppe");
            Add("\n选择日期和时间,并指定格式", "\nSelects a date and time in a specified format", "\nAuswahl von Datum und Uhrzeit in einem festgelegten Format");
            Add("显示一个可编辑的文本框,其中包括一个一个允许值下拉列表", "Displays an editable text box with a drop-down list of permitted values", "Zeigt ein bearbeitbares Textfeld mit einer Dropdownliste zulässiger Werte an");
            Add("显示用户可以从中选择项的列表", "Displays a list from which the user can select items", "Zeigt eine Liste an, aus der der Benutzer Elemente auswählen kann");
            Add("为控件提供说明性文字", "Provides descriptive text for a control", "Stellt beschreibenden Text für ein Steuerelement bereit");
            Add("从外部加载的.net控件\n位置:", "External .NET control\nLocation:", "Extern geladenes .NET-Steuerelement\nPfad:");

            //提示信息与对话框
            Add("提示", "Notice", "Hinweis");
            Add("新建设计", "New design", "Neuer Entwurf");
            Add("设计界面", "Design surface", "Entwurfsoberfläche");
            Add("自由型设计", "Free-form design", "Freier Entwurf");
            Add("编辑SQL", "Edit SQL", "SQL bearbeiten");
            Add("net程序集(*.dll)|*.dll", ".NET assembly (*.dll)|*.dll", ".NET-Assembly (*.dll)|*.dll");
            Add("不可识别程序集！", "Unrecognized assembly!", "Assembly nicht erkannt!");
            Add("没有任何控件,不能保存.", "There are no controls, nothing to save.", "Keine Steuerelemente vorhanden, Speichern nicht möglich.");
            Add("请选择保存路径与文件名", "Choose a location and file name", "Speicherort und Dateinamen wählen");
            Add("文本文件|*.txt|所有文件|*.*", "Text files|*.txt|All files|*.*", "Textdateien|*.txt|Alle Dateien|*.*");
            Add("当前设计将被覆盖,确定新建吗?\n建议先保存当前设计", "The current design will be overwritten. Continue?\nIt is recommended to save the current design first.", "Der aktuelle Entwurf wird überschrieben. Fortfahren?\nEs wird empfohlen, den aktuellen Entwurf zuerst zu speichern.");
            Add("请选择文本文件", "Select a text file", "Textdatei auswählen");
            Add("你不能在设计器外面创建控件", "You cannot create controls outside the designer.", "Steuerelemente können nicht außerhalb des Designers erstellt werden.");
            Add("当前设计器没有任何控件,\n请先添加控件再进行此操作.", "The designer contains no controls.\nPlease add controls first.", "Der Designer enthält keine Steuerelemente.\nBitte zuerst Steuerelemente hinzufügen.");
            Add("当前设计器控件不足两个,\n对齐操作无意义.", "The designer contains fewer than two controls,\naligning is not meaningful.", "Der Designer enthält weniger als zwei Steuerelemente,\nAusrichten ist nicht sinnvoll.");

            //添加控件对话框
            Add("确定", "OK", "OK");
            Add("取消", "Cancel", "Abbrechen");
            Add("程序集中的控件列表", "Controls in assembly", "Steuerelemente in der Assembly");

            //SQL编辑器
            Add("文件(F)", "File", "Datei");
            Add("保存(S)", "Save", "Speichern");
            Add("编辑(E)", "Edit", "Bearbeiten");
            Add("撤销(U)", "Undo", "Rückgängig");
            Add("恢复(Y)", "Redo", "Wiederholen");
            Add("剪切(T)", "Cut", "Ausschneiden");
            Add("复制(C)", "Copy", "Kopieren");
            Add("粘贴(P)", "Paste", "Einfügen");
            Add("删除(L)", "Delete", "Löschen");
            Add("全选(A)", "Select all", "Alles auswählen");
            Add("格式(O)", "Format", "Format");
            Add("自动换行(W)", "Word wrap", "Zeilenumbruch");
            Add("字体(F)...", "Font...", "Schriftart...");
            Add("查看(V)", "View", "Ansicht");
            Add("状态栏(S)", "Status bar", "Statusleiste");
            Add("第{0}行", "Line {0}", "Zeile {0}");
            Add("共{0}个字符", "{0} characters", "{0} Zeichen");
            Add("退出前是否保存编辑信息？", "Save changes before closing?", "Änderungen vor dem Schließen speichern?");

            //属性窗口
            Add("文本", "Text", "Text");
            Add("背景色", "BackColor", "Hintergrundfarbe");
            Add("颜色", "ForeColor", "Vordergrundfarbe");
            Add("字体", "Font", "Schriftart");
            Add("位置", "Location", "Position");
            Add("大小", "Size", "Größe");
            Add("边距", "Margin", "Außenabstand");
            Add("锚", "Anchor", "Verankerung");
            Add("停靠", "Dock", "Andocken");
            Add("Tab索引", "TabIndex", "Tab-Index");
            Add("SQL语句", "SQL statement", "SQL-Anweisung");
            Add("多行显示", "Multiline", "Mehrzeilig");
            Add("格式化", "CustomFormat", "Formatierung");
            Add("数据", "Data", "Daten");
            Add("外观", "Appearance", "Darstellung");
            Add("布局", "Layout", "Layout");
            Add("行为", "Behavior", "Verhalten");
            Add("Text 要显示的内容。", "Text: the content to display.", "Text: der anzuzeigende Inhalt.");
            Add("BackColor 背景色。", "BackColor: the background color.", "BackColor: die Hintergrundfarbe.");
            Add("ForeColor 前景色。", "ForeColor: the foreground color.", "ForeColor: die Vordergrundfarbe.");
            Add("Font 字体。", "Font: the font.", "Font: die Schriftart.");
            Add("Location 控件左上角相对于其容器左上角的坐标。", "Location: the coordinates of the upper-left corner of the control relative to the upper-left corner of its container.", "Location: die Koordinaten der oberen linken Ecke des Steuerelements relativ zur oberen linken Ecke seines Containers.");
            Add("Size 控件的大小，以像素为单位。", "Size: the size of the control, in pixels.", "Size: die Größe des Steuerelements in Pixeln.");
            Add("Margin 指定此控件与另一控件之间边距的距离。", "Margin: the space between this control and another control.", "Margin: der Abstand zwischen diesem und einem anderen Steuerelement.");
            Add("Anchor 定义要绑定到容器的边缘，当控件锚定位到某个控件时，与指定边缘最接近的控件边缘与指定边缘之间的距离将保持不变。", "Anchor: the edges of the container the control is bound to. When a control is anchored to an edge, the distance between the control's closest edge and the specified edge remains constant.", "Anchor: die Kanten des Containers, an die das Steuerelement gebunden ist. Ist ein Steuerelement an einer Kante verankert, bleibt der Abstand zwischen der nächstgelegenen Kante des Steuerelements und dieser Kante konstant.");
            Add("Dock 定义要绑定到容器的控件边框。", "Dock: the control borders that are docked to the container.", "Dock: die Rahmen des Steuerelements, die am Container angedockt werden.");
            Add("TabIndex 确定此控件将占用的 Tab 键顺序索引。", "TabIndex: the tab order index of this control.", "TabIndex: die Position des Steuerelements in der Tab-Reihenfolge.");
            Add("当前文档的SQL语句。", "The SQL statement of the current document.", "Die SQL-Anweisung des aktuellen Dokuments.");
            Add("Multiline 控件的文本是否能跨越多行。", "Multiline: whether the text of the control can span multiple lines.", "Multiline: ob der Text des Steuerelements mehrere Zeilen umfassen kann.");
            Add("CustomFormat 用于格式化在控件中显示的日期/或时间的自定义字符串。", "CustomFormat: the custom format string used to display the date and/or time in the control.", "CustomFormat: die benutzerdefinierte Formatzeichenfolge für die Anzeige von Datum und/oder Uhrzeit im Steuerelement.");
        }

        private static void Add(string zh, string en, string de)
        {
            _texts[zh] = new string[] { en, de };
        }

        /// <summary>
        /// 当前界面语言
        /// </summary>
        public static Language Current
        {
            get { return _current; }
            set { _current = value; }
        }

        /// <summary>
        /// 翻译
        /// </summary>
        /// <param name="zh">中文原文</param>
        /// <returns>当前语言的文本,找不到翻译时返回原文</returns>
        public static string T(string zh)
        {
            if (zh == null || _current == Language.Chinese)
                return zh;
            string[] texts;
            if (_texts.TryGetValue(zh, out texts))
                return texts[_current == Language.English ? 0 : 1];
            return zh;
        }

        /// <summary>
        /// 翻译并格式化
        /// </summary>
        public static string T(string zh, params object[] args)
        {
            return string.Format(T(zh), args);
        }

        /// <summary>
        /// 从用户设置读取界面语言
        /// </summary>
        public static void Load()
        {
            try
            {
                _current = (Language)Enum.Parse(typeof(Language), Properties.Settings.Default.Language, true);
            }
            catch
            {
                _current = Language.Chinese;
            }
        }

        /// <summary>
        /// 将界面语言保存到用户设置
        /// </summary>
        public static void Save()
        {
            Properties.Settings.Default.Language = _current.ToString();
            Properties.Settings.Default.Save();
        }
    }
}
