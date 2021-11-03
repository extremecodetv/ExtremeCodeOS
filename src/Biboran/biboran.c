
#include<gtk/gtk.h>
#include<stdio.h>
#include<stdlib.h>

enum __MAIN_SIZE{ _W=500,
                  _H=500 }; // Main window size.

enum __SUB_SIZE{ _SUB_W=900,
                 _SUB_H=700 }; // Sub window size.

#define _ICON    "res/icon.png"
#define _IMAGE   "res/abdul.png"
#define _BIBORAN "res/biboran.txt"

#ifndef BOOL
typedef char BOOL;
#endif

BOOL __READ_OPEN = FALSE; // Won't allow to create more than one read window.

#ifndef _string
typedef char* _string;
#endif

#define DEBUG // Debug mode with some extra logs.

#define __BUFFER_FAILED(buffer)\
    do {\
        buffer = (_string)malloc(1);\
        memset(buffer, 0, sizeof(buffer));\
        return buffer;\
    } while(0)

#define __FREE_CLOSE(file, buffer)\
    do {\
        free(buffer);\
        fclose(file);\
    } while(0)

// Destroy widget macro.
#define __DESTROY(widget)\
    do {\
        g_signal_connect(widget,\
                        "destroy",\
                        G_CALLBACK (widget_destroy),\
                        NULL);\
    } while(0)


// Get content from some file and write it to buffer.
_string get_buffer_from_file(_string filename) {
    static _string buffer;
    FILE* file = fopen(filename, "r");
    
    if (file == NULL) {
        fprintf(stderr, "Failed to read \"%s\"\n.", filename);
        __BUFFER_FAILED(buffer);    
    }

    if (fseek(file, 0L, SEEK_END) == 0) {
        long b_size = ftell(file);
        if (b_size == -1) {
            fprintf(stderr, "Failed to get file length.\n");
            fclose(file);
            __BUFFER_FAILED(buffer);
        }
        buffer = (_string)malloc(sizeof(char)*b_size+1);
        if (fseek(file, 0L, SEEK_SET) != 0) {
            fprintf(stderr, "Failed to get back to the begining of the file.\n");
            __FREE_CLOSE(file, buffer);
            __BUFFER_FAILED(buffer);
        }

        size_t n_l = fread(buffer, sizeof(char), b_size, file);
        if (ferror(file) != 0) {
            fprintf(stderr, "Error occured while reading from file to buffer!\n");
            __FREE_CLOSE(file, buffer);
            __BUFFER_FAILED(buffer);
        }
        else
            buffer[n_l+1] = 0;
    }

    fclose(file);
    return buffer;
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

void window_set_icon(GtkWidget* window, const gchar* filename) {
    GdkPixbuf* icon;
    icon = create_pixbuf_from_file(filename);
    gtk_window_set_icon(GTK_WINDOW (window), icon);
    g_object_unref(icon);
}

// Destroy callback function for read window.
void widget_destroy(GtkWidget* p_wid, gpointer _) {
    __READ_OPEN = FALSE;
    gtk_widget_destroy(p_wid);
#ifdef DEBUG
    fprintf(stdout, "[widget_destroy] function call.\n");
#endif
}

// Create read window widget.
void read_window_create(GtkWidget* p_wid, gpointer data) {
#ifdef DEBUG
    fprintf(stdout, "__READ_OPEN  = %s\n",
            (__READ_OPEN) ? "true" : "false");
#endif

    // Looks like kakoy-to kostil.
    if (__READ_OPEN) return;
    __READ_OPEN = TRUE;

    // Set main and scrollable windows.
    GtkWidget* read_win = window_init(_SUB_W,
                                      _SUB_H, 
                                      "Священный Биборан.");
    GtkWidget* scrolled_read = gtk_scrolled_window_new(NULL, NULL);
    gtk_widget_show(scrolled_read);

    // When window is closed destroy it's widget.
    __DESTROY(read_win);
    __DESTROY(scrolled_read);

    // Default icon.
    window_set_icon(read_win, _ICON);

    // Read saint Biborant to buffer.
    static _string buffer;
    buffer = get_buffer_from_file(_BIBORAN);
#ifdef DEBUG
    fprintf(stdout, "%s\n", buffer);
    fprintf(stdout, "%d %d\n", strlen(buffer), sizeof(buffer));
#endif

    // Create text area label with text from buffer.
    GtkWidget* text_area;
    text_area = gtk_label_new(buffer);
    gtk_widget_show(text_area);

    __DESTROY(text_area);

    // Set read frame widget.
    GtkWidget* read_frame;
    read_frame = gtk_frame_new(" Анша Абдуль!");
    gtk_widget_show(read_frame);
    
    __DESTROY(read_frame);

    // Set grid for text.
    GtkWidget* grid;
    grid = gtk_grid_new();
    gtk_widget_show(grid);

    __DESTROY(grid);

    // Pack widgets one by one.
    gtk_container_add(GTK_CONTAINER (read_win),
                      scrolled_read);
    gtk_container_add(GTK_CONTAINER (scrolled_read),
                      read_frame);
    gtk_container_add(GTK_CONTAINER (read_frame),
                      grid);
    gtk_grid_attach(GTK_GRID (grid),
                    text_area,
                    0, 0, 1, 1);

    // Set text align to center.
    gtk_widget_set_vexpand(text_area, TRUE);
    gtk_widget_set_hexpand(text_area, TRUE);

    gtk_widget_show_all(read_win);
    // Free buffer memory.
    free(buffer);

#ifdef DEBUG
    fprintf(stdout, "%d\n", sizeof(buffer));
#endif
}

// Initialise button with label and pack it to the general box.
GtkWidget* init_and_pack_button(GtkWidget* box, _string label) {
    static GtkWidget* button;
    button = gtk_button_new_with_label(label);
    gtk_box_pack_start(GTK_BOX (box),
                       button,
                       TRUE,
                       TRUE,
                       0);
    return button;
}

// Initialise frame with shadow and pack it to the general container.
GtkWidget* init_frame_with_shadow(_string label, GtkWidget* container) {
    static GtkWidget* frame;
    frame = gtk_frame_new(label);
    gtk_widget_show(frame);

    gtk_frame_set_shadow_type(GTK_FRAME (frame),
                              GTK_SHADOW_IN);
    gtk_frame_set_label_align(GTK_FRAME (frame),
                             .5, 0);
    gtk_container_add(GTK_CONTAINER (container),
                      frame);

    return frame;
}

int main(int argc, char** argv) {

    // Init main window and the gtk itself.
    gtk_init(&argc, &argv);

    GtkWidget* win;
    win = window_init(_W,
                      _H,
                      "Biboran");
    window_set_icon(win, _ICON);

    g_signal_connect(win,
                    "destroy",
                    G_CALLBACK (gtk_main_quit),
                    NULL);

    // Main Vbox init.
    GtkWidget* main_vbox;
    main_vbox = gtk_vbox_new(FALSE, 1);
    gtk_container_add(GTK_CONTAINER (win), main_vbox);

    // Top frame init.
    GtkWidget* top_frame;
    top_frame = init_frame_with_shadow("# Кара вечная #", main_vbox);

    // Abdul'
    GtkWidget* abdul;
    abdul = gtk_image_new_from_file(_IMAGE);
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
    g_signal_connect(read_but,
                    "clicked",
                    G_CALLBACK (read_window_create),
                    NULL);

    // Quit button.
    GtkWidget* quit_but;
    quit_but = init_and_pack_button(sub_hbox, "ВЫЙТИ");
    g_signal_connect(quit_but,
                    "clicked",
                     G_CALLBACK (gtk_main_quit),
                     NULL);

    // Show main window.
    gtk_widget_show_all(win);

    gtk_main();

    return 0;
}

