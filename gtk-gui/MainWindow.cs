
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox vbox1;

	private global::Gtk.HBox hbox2;

	private global::Gtk.Button file_chooser_btn;

	private global::Gtk.Label lexemes_label;

	private global::Gtk.Label symbol_table_label;

	private global::Gtk.HBox hbox1;

	private global::Gtk.ScrolledWindow GtkScrolledWindow3;

	private global::Gtk.TextView codeView;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.TreeView lexemeView;

	private global::Gtk.ScrolledWindow GtkScrolledWindow1;

	private global::Gtk.TreeView symbolTableView;

	private global::Gtk.Button execute_btn;

	private global::Gtk.ScrolledWindow GtkScrolledWindow2;

	private global::Gtk.TextView consoleView;

	private global::Gtk.Label inputLabel;

	private global::Gtk.Entry inputEntry;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox();
		this.hbox2.Name = "hbox2";
		this.hbox2.Homogeneous = true;
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.file_chooser_btn = new global::Gtk.Button();
		this.file_chooser_btn.CanFocus = true;
		this.file_chooser_btn.Name = "file_chooser_btn";
		this.file_chooser_btn.UseUnderline = true;
		this.file_chooser_btn.Label = global::Mono.Unix.Catalog.GetString("Choose File...");
		this.hbox2.Add(this.file_chooser_btn);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.file_chooser_btn]));
		w1.Position = 0;
		w1.Expand = false;
		w1.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.lexemes_label = new global::Gtk.Label();
		this.lexemes_label.Name = "lexemes_label";
		this.lexemes_label.LabelProp = global::Mono.Unix.Catalog.GetString("Lexemes");
		this.hbox2.Add(this.lexemes_label);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.lexemes_label]));
		w2.Position = 1;
		w2.Expand = false;
		w2.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.symbol_table_label = new global::Gtk.Label();
		this.symbol_table_label.Name = "symbol_table_label";
		this.symbol_table_label.LabelProp = global::Mono.Unix.Catalog.GetString("Symbol Table");
		this.hbox2.Add(this.symbol_table_label);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.symbol_table_label]));
		w3.Position = 2;
		w3.Expand = false;
		w3.Fill = false;
		this.vbox1.Add(this.hbox2);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
		w4.Position = 0;
		w4.Expand = false;
		w4.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox();
		this.hbox1.HeightRequest = 250;
		this.hbox1.Name = "hbox1";
		this.hbox1.Homogeneous = true;
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow3 = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow3.Name = "GtkScrolledWindow3";
		this.GtkScrolledWindow3.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow3.Gtk.Container+ContainerChild
		this.codeView = new global::Gtk.TextView();
		this.codeView.CanFocus = true;
		this.codeView.Name = "codeView";
		this.GtkScrolledWindow3.Add(this.codeView);
		this.hbox1.Add(this.GtkScrolledWindow3);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.GtkScrolledWindow3]));
		w6.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.lexemeView = new global::Gtk.TreeView();
		this.lexemeView.CanFocus = true;
		this.lexemeView.Name = "lexemeView";
		this.GtkScrolledWindow.Add(this.lexemeView);
		this.hbox1.Add(this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.GtkScrolledWindow]));
		w8.Position = 1;
		// Container child hbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
		this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
		this.symbolTableView = new global::Gtk.TreeView();
		this.symbolTableView.CanFocus = true;
		this.symbolTableView.Name = "symbolTableView";
		this.GtkScrolledWindow1.Add(this.symbolTableView);
		this.hbox1.Add(this.GtkScrolledWindow1);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.GtkScrolledWindow1]));
		w10.Position = 2;
		this.vbox1.Add(this.hbox1);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
		w11.Position = 1;
		// Container child vbox1.Gtk.Box+BoxChild
		this.execute_btn = new global::Gtk.Button();
		this.execute_btn.CanFocus = true;
		this.execute_btn.Name = "execute_btn";
		this.execute_btn.UseUnderline = true;
		this.execute_btn.Label = global::Mono.Unix.Catalog.GetString("EXECUTE");
		this.vbox1.Add(this.execute_btn);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.execute_btn]));
		w12.Position = 2;
		w12.Expand = false;
		w12.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow2 = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
		this.GtkScrolledWindow2.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
		this.consoleView = new global::Gtk.TextView();
		this.consoleView.HeightRequest = 250;
		this.consoleView.CanFocus = true;
		this.consoleView.Name = "consoleView";
		this.GtkScrolledWindow2.Add(this.consoleView);
		this.vbox1.Add(this.GtkScrolledWindow2);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow2]));
		w14.Position = 3;
		// Container child vbox1.Gtk.Box+BoxChild
		this.inputLabel = new global::Gtk.Label();
		this.inputLabel.Name = "inputLabel";
		this.inputLabel.LabelProp = global::Mono.Unix.Catalog.GetString("Input Here");
		this.vbox1.Add(this.inputLabel);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.inputLabel]));
		w15.Position = 4;
		w15.Expand = false;
		w15.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.inputEntry = new global::Gtk.Entry();
		this.inputEntry.CanFocus = true;
		this.inputEntry.Name = "inputEntry";
		this.inputEntry.IsEditable = true;
		this.inputEntry.InvisibleChar = '•';
		this.vbox1.Add(this.inputEntry);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.inputEntry]));
		w16.Position = 5;
		w16.Expand = false;
		w16.Fill = false;
		this.Add(this.vbox1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 912;
		this.DefaultHeight = 659;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.file_chooser_btn.Clicked += new global::System.EventHandler(this.OnFileChooserBtnClicked);
		this.execute_btn.Clicked += new global::System.EventHandler(this.OnExecuteBtnClicked);
	}
}
