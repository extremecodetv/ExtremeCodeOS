
#include<gtk/gtk.h>
#include<stdio.h>

enum __MAIN_SIZE{ _W=500,
                  _H=500 }; // Main window size.

enum __SUB_SIZE{ _SUB_W=1000,
                 _SUB_H=700 }; // Sub window size.

#ifndef _string
typedef char* _string;
#endif

#define DEBUG


// General function for window initialisation.
GtkWidget* window_init(int _w, int _h, _string title) {
    static GtkWidget* win;
    win = gtk_window_new(GTK_WINDOW_TOPLEVEL);
    gtk_window_set_title(GTK_WINDOW (win), title);
    gtk_window_set_default_size(GTK_WINDOW (win), _w, _h);
    gtk_window_set_position(GTK_WINDOW (win), GTK_WIN_POS_CENTER);
#ifdef DEBUG
    fprintf(stdout, "[window_init] function call, window %dx%d, title %s\n",
            _w, _h, title);
#endif
    return win;
}

// Destroy callback function for read window.
void read_window_destroy(GtkWidget* p_wid, gpointer _) {
    gtk_widget_destroy(p_wid);
#ifdef DEBUG
    puts("[read_window_destroy] function call.");
#endif
}

// Create read window widget.
void read_window_create(GtkWidget* p_wid, gpointer data) {
    GtkWidget* read_win = window_init(_SUB_W, _SUB_H, "Священный Биборан.");
    // When window is closed destroy it's widget.
    g_signal_connect(read_win, "destroy",
            G_CALLBACK(read_window_destroy), NULL);
    gtk_widget_show_all(read_win);
}

// Default function to create GDK pixbuffers from files.
GdkPixbuf* create_pixbuf_from_file(const gchar* filename) {
    GdkPixbuf* pixbuf;
    GError* error = NULL;
    // if thepixbuf creating is failed pointer will be set.
    pixbuf = gdk_pixbuf_new_from_file(filename, &error);
    // File not exist or path is invalid, probably.
    if (!pixbuf) {
        fprintf(stderr, "%s\n", error->message);
        g_error_free(error);
    }
    return pixbuf;
}

// Initialise button with label and pack it to the general box.
GtkWidget* init_and_pack_button(GtkWidget* box, _string label) {
    static GtkWidget* button;
    button = gtk_button_new_with_label(label);
    gtk_box_pack_start(GTK_BOX (box), button, TRUE, TRUE, 0);
    return button;
}

// Initialise frame with shadow and pack it to the general container.
GtkWidget* init_frame_with_shadow(_string label, GtkWidget* container) {
    static GtkWidget* frame;
    frame = gtk_frame_new(label);
    gtk_widget_show(frame);

    gtk_frame_set_shadow_type(GTK_FRAME (frame), GTK_SHADOW_IN);
    gtk_frame_set_label_align(GTK_FRAME (frame), .5, 0);
    gtk_container_add(GTK_CONTAINER (container), frame);

    return frame;
}

int main(int argc, char** argv) {

    // Init main window and the gtk itself.
    gtk_init(&argc, &argv);

    GtkWidget* win;
    win = window_init(_W, _H, "Biboran");

    g_signal_connect(win, "destroy",
            G_CALLBACK (gtk_main_quit), NULL);

    // Application icon.
    GdkPixbuf* icon;
    icon = create_pixbuf_from_file("res/icon.png");
    gtk_window_set_icon(GTK_WINDOW (win), icon);
    g_object_unref(icon);

    // Main Vbox init.
    GtkWidget* main_vbox;
    main_vbox = gtk_vbox_new(FALSE, 1);
    gtk_container_add(GTK_CONTAINER (win), main_vbox);

    // Top frame init.
    GtkWidget* top_frame;
    top_frame = init_frame_with_shadow("# Кара вечная #", main_vbox);

    // Abdul'
    GtkWidget* abdul;
    abdul = gtk_image_new_from_file("res/abdul.png");
    gtk_widget_show(abdul);
    gtk_container_add(GTK_CONTAINER (top_frame), abdul);

    // Bot frame init.
    GtkWidget* bot_frame;
    bot_frame = init_frame_with_shadow("# интерактивное меню #", main_vbox);

    // Sub vbox with button init. 
    GtkWidget* sub_hbox;
    sub_hbox = gtk_hbox_new(TRUE, 1);
    gtk_widget_show(sub_hbox);
    gtk_container_add(GTK_CONTAINER (bot_frame), sub_hbox);

    // Read button.
    GtkWidget* read_but;
    read_but = init_and_pack_button(sub_hbox, "ЧИТАТЬ");
    g_signal_connect(read_but, "clicked",
            G_CALLBACK (read_window_create), NULL);

    // Quit button.
    GtkWidget* quit_but;
    quit_but = init_and_pack_button(sub_hbox, "ВЫЙТИ");
    g_signal_connect(quit_but, "clicked",
            G_CALLBACK (gtk_main_quit), NULL);

    // Show main window.
    gtk_widget_show_all(win);

    gtk_main();

    return 0;
}

