   M S B A M L   `   `   `  ����K  GLoginWPF.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:LoginWPF.Windows.ControlsLoginWPF.Windows.Controls  5      2    ,LoginWPF.Windows.Controls.ProveedoresControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:LoginWPF.Windows.Controls     5        � 	Resources  5	      2  ,System.Windows.Controls.AlternationConverter   AlternationConverter  DataGridCellStyle1 �� 
TargetType*  $System.Windows.Controls.DataGridCell �� Property �� Value �� 
TargetType J� SnapsToDevicePixels �� ContentStringFormat �� ContentStringFormat �� Triggers	 P� Property
 P� Value �� 
ResourceId �� TypeInTargetAssembly&   System.Windows.Controls.DataGrid ]� 
Conditions �� Property �� Value ^� 
Conditions �� Binding �� StrokeDashArray  DataGridControlTemplate1 � 	Resources  Key �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value ��Name �� Padding ��Name � ColumnDefinitions � RowDefinitions �� RelativeSource �� AncestorLevel �� AncestorType  �� Path! �� ConverterParameter7  1System.Windows.Controls.DataGridHeadersVisibilityG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter"  Name# ��Name$ �� CanContentScroll% �� CanHorizontallyScroll& �� CanVerticallyScroll' ��Name( �� ScrollableHeight) � Maximum* �� Orientation*+ �� #ComputedVerticalScrollBarVisibility, �� ViewportHeight- �� ViewportSize. � Value/ �� Mode0 �� ScrollableWidth,1 �� %ComputedHorizontalScrollBarVisibility2 �� ViewportWidth3 �� Triggers4 :� RoutedEvent  	OnLoaded1  LabelStyle1  
GridStyle15 �� 	Resources��%<  &	        &	      &	 �    7  &	 `    7  &	 �    7    5
   
   6   �� 5   
   "  6+   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 ���� 6,   �� 5       � ��$ 1q�60   �� 5       � �� 5      �� 5      "  6&   .R�5      �� #��z��6!   #��z��6M   #��z��6�    . ._�5      �� #��z��6/   #��z��6c   # z 6�   # z 6�   $��Center=�6�   $��Center=�6  $
��10,0q�67  5      5      5       5      P� 5      	 �@ 
IsSelected
 . . �5      ��  � ��# � ��63   �� 5       � ��# � ��63   �� 5       � ��# � ��64   5      P� 5      	 �@J�IsKeyboardFocusWithin
 . . �5      ��  � �� 64   C� *�� $ FocusBorderBrushKey��"  +5       ]� 5!       5"      �� 5#       �@ 
IsSelected . 6:   �� 5$       �@��IsSelectionActive .  6J   ./�5&      ��  � �� 63   C� �� 5'       � �� 64   C� �� 5(       � �� 63   C� 5)      P� 5*      	 � {�
 .  . �5+      ��  � ��# � ��63   5,      ^� 5-       5.      �� 5/       6$   �� *(0)+	 false6<   �� 50       6$   �� *(0)+ true6<   .0�52      ��  �@�FocusVisualStyle 53      �� 54      .�55   "   ��  � �� 56   &   �� 57   *   .R�58   .   � .+�59   2   �� $��1q�6<    . #��� ��6b   $��1��6�   �� 5:   2   $��1q�6<    . #��� ��6b   $��1��6�   $	 2 2R�6�   5;   /   5<   +   5>   #   5?      5A      5B      5D      �� 5E   
   "  6;    5F      ���� 5G      	OnLoaded1 .��5H      U� $ (UIElement.Opacity)�64   $ border��6d   .\�5I        $ 0��6/   $ 0Q�6;     5J      $ 0:0:0.5��6/   $ 1Q�6A   5K      5L      5M      .R�5N      �� $ border��6   #��z��6%   #��z��6Q   #��z��6�   # z��6�    . ._�5O      �� $ DG_ScrollViewer��6   |�.  ��5P      �� 5Q      " ��6*   .R�5R      �  5S   "   �� 5T   &   $
��Auto �67   �� 5U   &   $��* �67   �� 5V   &   $
��Auto �67    5X   "   �� 5Y   &   $
��Auto �64   �� 5Z   &   $��* �64   �� 5[   &   $
��Auto �64   .+�5]   "   �� $#��ApplicationCommands.SelectAll��6)   |�.  ��6c   C� *�� $" DataGridSelectAllButtonStyle��"  +��6�   �� *CellsPanelHorizontalOffset+ �� *FindAncestor+$ 1��"  y�5^   &   �� 5_   *   $  HeadersVisibility�62    6K   �� *FindAncestor+$ 1��"  ! 5`   .    5a   2   All=�6Q   5c   +   5e   #     5f   "   $!" PART_ColumnHeadersPresenter��6A   $��1��6f   y�5g   &   �� 5h   *   $  HeadersVisibility�62    6K   �� *FindAncestor+$ 1��"  ! 5i   .    5j   2   
Column=�6T   5l   +   5n   #   �� 5o   "   $!# PART_ScrollContentPresenter��69   #$ z��6^   % .  $��2��6�   & .  #��z��6�   #��z��6  # z 6:  $��1��6v  �� 5p   "   $' PART_VerticalScrollBar��6,   $��2��6L   #) z( 6\   $* Vertical=�6�   $��1��6�   #y�z+ 6�   #- z, 6O  . 6�   �� *VerticalOffset+$/ OneWay=� �� *TemplatedParent+6O  � 5q   "   $��1��6'   $��2��67    5r   &   �� 5s   *   ��6;   �� **(NonFrozenColumnsViewportHorizontalOffset+ �� *FindAncestor+$ 1��"  �� 5t   *   $��* �6;   .+�5v   &   �� $' PART_HorizontalScrollBar��60   $��1��6R   #) z0 6b   $* 
Horizontal=�6�   #y�z1 6�   #- z2 6M  . 6�   �� *HorizontalOffset+$/ OneWay=� �� *TemplatedParent+6M  5w   #   5x      5y      .��5{      �� # z 6%   5|      5}      3 5~      :� 5      $4 FrameworkElement.Loaded��6   .[�5�      �� 8��  6&   5�      5�      �� 5�   
   " ��6$   .�5�      ��  � ��# � ��6+   �� 5�       � ��
 ���� 6+   �� 5�       � ��$ 5q�6(   �� 5�       � ��$
 Left=�6;   �� 5�       � ��$	 Top=�69   �� 5�       � �� 5�      �� 5�      " ��6&    5�      ���� 5�      	OnLoaded1 .��5�   "   U� $ (UIElement.Opacity)�6@   $ border��6p   .\�5�   &     $ 0��6;   $ 0Q�6G     5�   &   $ 0:0:0.5��6;   $ 1Q�6M   5�   #   5�      5�      .R�5�      �� $ border��6!   #��z��61   #��z��6]   #��z��6�   # z��6�    . ._�5�      �� #��z��6/   #��z��6c   # z 6�   #��z��6�   ��. # z 6!  #��z��6]  5�      3 5�      :� 5�      $4 FrameworkElement.Loaded��6+   .[�5�   "   �� 8��  62   5�      P� 5�      	 � {�
 .  . �5�   "   �� # � ��6?    � ��5�      5�      5�      5�      �� 5�   
   " �6#   5 5�      ���� 5�      	OnLoaded1 .��5�      U� $ (UIElement.Opacity)�64    6d   Z� .\�5�        $ 0��6/   $ 0Q�6;     5�      $ 0:0:0.3��6/   $ 1Q�6A   5�      5�      5�       5�      :� 5�      $4 FrameworkElement.Loaded��6   .[�5�      �� 8��  6&   5�      .�5�      ��  �@J�RenderTransformOrigin$ 0.5,0.5&�66   �� 5�       � z� 5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      5�      5�      .��5�      � -   5        6 �Name$6 gridControl��5�      $��Stretch=�6    $��Stretch=�6>   $��10,10,10,10q�6Z   #���  6o    5�   
   �� 5�      $	��26* �6   �� 5�      $
��229* �6   �� 5�      $	��35* �6    5�   
   �� 5�      .+�5�   
   �� $��0��6   $��0��6   $��Proveedores��6-   $��36(�6C   $��
Lucida Fax)�6Q   
�������#���  6|   $
��Bold"�6�   $��0q�6�   $��Center=�6�   $��Center=�6�   $
��Left=�6    5�   
   -   5        7  Name$7 gridProductos��5�      $��Stretch=�6+   $��Stretch=�6G   $��0��6e   $��1��6u   $��14(�6�   4  .System.Windows.Automation.AutomationProperties8   IsColumnHeader8 . 9   HeadersVisibility$9 Column=�6�   :   SelectionMode$: Single=�6�   ;   CanUserResizeRows; .  <   MinRowHeight$< 9Q�6  =   	CellStyle#= �  6.  #���  6_  
�������$��0q�6�  ��6�   Z� >   Columns> 5�      4  .System.Windows.Controls.DataGridCheckBoxColumn  5�      ,	  &System.Windows.Controls.DataGridColumn? 	  Header$? Select��6_   1
  +System.Windows.Controls.DataGridBoundColumn@ 
  Binding@ 6)   Z� A 
  ClipboardContentBindingA 6<   Z� 6_   5�      � 5�   
   $��2��6    5�      �� 5�      $��2* �6#   60   �� 5�      $��2* �6#   60   �� 5�      $��2* �6#   60   �� 5�      $��2* �6#   60   �� 5�      $��2* �6#   60   �� 5�      $��2* �6#   60   .+�5�      �� -   5        B ��Name$B BtnAdd��5�   %   $��3��6   $��10,10,10,10q�65   $��Nuevo Proveedor��6J     ButtonStyle1#���  6d   
�������
���   �$��14(�6�   $
��Bold"�6�   C � Cursor$
C Hand��6�   �� 5�      -   5        $B 	BtnUpdate��5�   %   $��4��6   $��10,10,10,10q�68   $��Modificar Proveedor��6M   $��14(�6k   #���  6y   
�������$
��Bold"�6�   $
C Hand��6�   
���   �6�   �� 5�      -   5        $B 	BtnDelete��5�   %   $��5��6   $��10,10,10,10q�69   $��Eliminar Proveedor��6N   $��14(�6k   #���  6y   
�������$
��Bold"�6�   $
C Hand��6�   
���   �6�   5�      5�      5�      