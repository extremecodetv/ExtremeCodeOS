
#include<gtk/gtk.h>
#include<stdio.h>

enum __MAIN_SIZE{ _W=500,
                  _H=500 }; // Main window size.

enum __SUB_SIZE{ _SUB_W=1000,
                 _SUB_H=700 }; // Sub window size.

#ifndef _string
typedef char* _string;
#endif


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
void init_and_pack_button(GtkWidget* box, _string label) {
    static GtkWidget* button;
    button = gtk_button_new_with_label(label);
    gtk_box_pack_start(GTK_BOX (box), button, FALSE, FALSE, 0);
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

    // Declare main window and init the gtk itself.
    GtkWidget* win;
    gtk_init(&argc, &argv);

    // Init main window.
    win = gtk_window_new(GTK_WINDOW_TOPLEVEL);
    gtk_window_set_title(GTK_WINDOW (win), "Biboran");
    gtk_window_set_default_size(GTK_WINDOW (win), _W, _H);
    gtk_window_set_position(GTK_WINDOW (win), GTK_WIN_POS_CENTER);

    g_signal_connect(win, "destroy",
            G_CALLBACK (gtk_main_quit), NULL);

    // Application icon.
    GdkPixbuf* icon;
    icon = create_pixbuf_from_file("res/icon.png");
    gtk_window_set_icon(GTK_WINDOW (win), icon);
    g_object_unref(icon);

    // Main frame init.
    //GtkWidget* main_frame;
    //main_frame = init_frame_with_shadow("Александр Гаврилович Абдуллов", win);

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


    //Bot frame init.
    GtkWidget* bot_frame;
    bot_frame = init_frame_with_shadow("# интерактивное меню #", main_vbox);

    // Sub vbox with button init. 
    GtkWidget* sub_vbox;
    sub_vbox = gtk_vbox_new(TRUE, 1);
    gtk_widget_show(sub_vbox);
    gtk_container_add(GTK_CONTAINER (bot_frame), sub_vbox);
    

    init_and_pack_button(sub_vbox, "ЧИТАТЬ");

    // Show main window.
    gtk_widget_show_all(win);

    gtk_main();

    return 0;
}
