   M S B A M L   `   `   `  ����J  FFileExplorerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FileExplorerWPFFileExplorerWPF  5   	   D @FluentWPF, Version=0.6.1.0, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF 5	   	        FileExplorerWPF.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:FileExplorerWPF     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   ?fw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF  5	   	   -   5        )  #SourceChord.FluentWPF.AcrylicWindow    Enabled  .    ShowTitleBar .  $	��700��5   0   $
��1110��6=    � WindowStyle$
 None=�6J    � AllowsTransparency .  � 
ResizeMode$ 	CanResize=�6w    � WindowStartupLocation$ CenterScreen=�6�   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��40* �6   �� 5      $
��181* �6   �� 5      .+�5   
   � -   5         �Name$ MenuGrid��5      $	��200��6!   $
��Left=�6-   *  $SourceChord.FluentWPF.PointerTracker   Enabled . ��5      �� 5      	 �� Color$	 	#FF8B8B8B��6"   
 �� Opacity$	
 0.6Q�64   .+�5      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TrainsitionigContentSlide��5   2   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6U   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.2X�.��5      � -   5        $ 
GridCursor��5      $��0,137q�6+   ���	#FF6B6B6B$��10��6Q   $
��Left=�6\   $��45��6w   $	��Top=�6�   5      �� 5      .+�5      �� -   5         ��Name$
 Menu��5      $��	145,0,0,0q�6,    �� Orientation$ 
Horizontal=�6?   .+�5      �� -   5        $��2,10,0,0q�5      
���   ���6C   Z� ��6Y   Z� .��5!      '  !MaterialDesignThemes.Wpf.PackIcon  $��20��62   $��20��6=   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$
 Menu=�6I   5"      5#      �� 5%      -   5        $��	SearchTxt��5%   B   $��  Search ... ��6   
�������$��Center=�6S   $��Italic$�6p   
�������$	��180��6�   $��10,20q�6�   4  .System.Windows.Automation.AutomationProperties   IsColumnHeader . 6  �� 5&      .+�5'      �� -   5         ��Name$ LocationLabel��5'       $��	Locations��67   $��15(�6H   $��	UltraBold"�6V   $��5q�6m   �� 5)      -	   5         ��Name$ Location��5)      $��Hidden=�61   $��17(�6f   $��JF Flat)�6t   .@�5+      �� $��45��6'   .��5,      �� $ 
Horizontal=�6)   .+�5-   "     $
 Home=�6:   $��8q�6F   �� 5.   "   $
��Home��6,   $��Center=�68   $
��10,0q�6S   5/      50      �� 51      $��45��6'   .��52      �� $ 
Horizontal=�6)   .+�53   "     $ Monitor=�6:   $��8q�6I   �� 54   "   $��Desktop��6,   $��Center=�6;   $
��10,0q�6V   55      56      �� 57      $��45��6'   .��58      �� $ 
Horizontal=�6)   .+�59   "     $ Download=�6:   $��8q�6J   �� 5:   "   $��Download��6,   $��Center=�6<   $
��10,0q�6W   5;      5<      �� 5=      $��45��6'   .��5>      �� $ 
Horizontal=�6)   .+�5?   "     $ FileDocumentOutline=�6:   $��8q�6U   �� 5@   "   $��	Documents��6,   $��Center=�6=   $
��10,0q�6X   5A      5B      �� 5C      $��45��6'   .��5D      �� $ 
Horizontal=�6)   .+�5E   "     $ Image=�6:   $��8q�6G   �� 5F   "   $��Picture��6,   $��Center=�6;   $
��10,0q�6V   5G      5H      �� 5I      $��45��6'   .��5J      �� $ 
Horizontal=�6)   .+�5K   "     $ Music=�6:   $��8q�6G   �� 5L   "   $��Music��6,   $��Center=�69   $
��10,0q�6T   5M      5N      �� 5O      $��45��6'   .��5P      �� $ 
Horizontal=�6)   .+�5Q   "     $ Video=�6:   $��8q�6G   �� 5R   "   $��Videos��6,   $��Center=�6:   $
��10,0q�6U   5S      5T      �� 5U      $��45��6'   .��5V      �� $ 
Horizontal=�6)   .+�5W   "     $ Notifications=�6:   $��8q�6O   �� 5X   "   $��Notifications��6,   $��Center=�6A   $
��10,0q�6\   5Y      5Z      5\      �� 5^      -
   5        $ DriverLabel��5^       $��Driver��65   $��15q�6C   $��15(�6O   $��	UltraBold"�6]   �� 5`      -   5        $ Drivers��5`      $��Hidden=�60   $��17(�6e   $��JF Flat)�6s   .@�5a      �� -   5        $��45��5a   '   .��5b      �� $ 
Horizontal=�6)   .+�5c   "     $ ComputerClassic=�6:   $��8q�6Q   $��20��6\   �� 5d   "   $��This PC��6,   $��Center=�6;   $
��10,0q�6V   5e      5f      5g      5i      5k      5l      � 5m   
   -   5        $ DisplayArea��5m      $��Right=�6%   $��3��6A   $	��910��6U   ��5n      �� 5o      $	 Black��6#   $

 0.85Q�61   .+�5r      �� $ 
Horizontal=�6   $��Right=�62   $��	0,0,0,573q�6N   .+�5s      �� -   5        
�������$��Right=�5s   -   $	��Top=�6I   ��6a   Z� ��6w   Z� .��5t        $ Minus=�6.   5u      �� 5v      -   5        
�������$	��Top=�5v   ,   $��Right=�6D   ��6`   Z� ��6v   Z� .��5w        -   5        $��maxOrMin��5w   .   $ SquareOutline=�6>   5x      �� 5y      -   5        
�������$	��Top=�5y   ,   $��Right=�6D   ��6`   Z� ��6v   Z� .��5z        $ Close=�6.   5{      5}      �� 5~      -   5        $ 	sortStack��5~      $	��200��6,   $��30��68   $	��Top=�6E   $��0,40,0,0q�6]   
�������$y�Hidden=�6�   .+�5      �� -   5         ��Name$ sortCombBox��5      
���   � �� Text$ Sort By .....��6C   $	��200��6X   $��30��6d    �� 
IsEditable .  �� 
IsReadOnly . .@�5�      �� 
���   �
�������.��5�      �� 
�������Date Modified6I   5�      �� 5�      
�������.��5�      �� 
���   �Alphabetically Ascending6Q   5�      �� 5�      
���   �
�������.��5�      �� 
�������Alphabetically Descending6R   5�      5�      5�      � 5�      -   5        $ plntContent��5�      $
��Left=�6(   $	��558��6C   $��	31,50,0,0q�6P   $	��Top=�6c   $	��853��6{   .+�5�      �� -   5         ��Name$ pnlItems��5�         ListBoxExplorerStyle#��[  6,   $��0,71,0,0q�6r   �� 5�      -   5        $y�Visible=�5�   0   $��40��6\   
�������$��	35,12,0,0q�6|   $
��Left=�6�   $	��Top=�6�   ��6   Z� ��6E   Z� .��5�        -   5          Name$ back_btn��5�   .   $ ArrowLeftBoldCircle=�6A   $��38��6_   $��32��6k   $y�Hidden=�6v   5�      '	  !MaterialDesignThemes.Wpf.PopupBox	  5�      -   5        $��Option��5�   *   $��Right=�68   
������� 	  PlacementMode$ BottomAndAlignRightEdges=�6m    	  	StaysOpen .  $��783,10,0,492q�6�   $��38��6�   $��32��6�    J� RenderTransformOrigin$ -0.625,2&�6�    	  PopupContent. 5�      �� $	��150��6!   .+�5�      �� -   5        $��Paste��5�   !   61   �� 5�      -   5        $��
New Folder��5�   !   66   5�      5�      � 5�      -   5        $ InputBox��5�      $y�	Collapsed=�6)   .+�5�      � 
���   � J� Opacity$	 0.5Q�6.   �� 5�      $	��250��5�      
�������
���   �$��1q�5�       �� CornerRadius$ 	0,55,0,55��5�      $��Center=�5�      $��Center=�5�      ._�5�      �� .+�5�      �� $��5q�6(   $��
Input Box:��63   $
��Bold"�6E   $��Cambria)�6W   $��15(�6l   
���   �6{   �� 5�      -   5          ��Name$  InputTextBox��5�   m   $	��150��6&   $��Center=�65   $��Center=�6R   $��15(�6�   
���   �6�   �� 5�      $ 
Horizontal=�6)   $��Center=�6B   .+�5�   "   �� -   5        ! ��Name$! 	YesButton��5�   )   $��5q�6<   $	��Yes��6G   
���   ���6U   Z� 6~   �� 5�   "   -   5        $! NoButton��5�   )   $��5q�6;   $��No��6F   
���   ���6S   Z� 6|   5�      5�      5�      5�      � 5�      -   5        $ GridPrincipal��5�      $��Center=�6.   $��Center=�6K   5�      � 5�      -    5        $ ActivityDisplay��5�      
������ $��0,40,0,0q�6F   $y�Hidden=�6X   .+�5�      � $	��Top=�6   .+�5�      �� ���	#FFB7B7B7$��Right=�6a   ��64   Z� ��6J   Z� 5�      �� 5�      ���	#FFB7B7B7$
��Left=�6a   ��64   Z� ��6J   Z� .��5�        $ Person=�62   $��20��6A   $��20��6L   5�      �� 5�      ���	#FFB7B7B7$��Activity��68   $��17(�6H   $
��Bold"�6V   $��10q�6h   $��Center=�6t   $��60��6�   5�      � 5�      $	��Top=�6   $��0,50,0,0q�6/   ���	#FFC2C5C9$��5��6X   $	��300��6c   " J� OpacityMask" �	#FF79838D5�      � 5�      $��0,55,0,0q�6   ���	#FF1C1A1D" 5�      �� 5�      # �� EndPoint$# 0.5,1&�6.   $ �� 
StartPoint$$ 0.5,0&�6?   .��5�      � % � Color$% Black��6+   & � Offset$
& 0.14Q�69   � 5�      $% 	#FFBDAFAF��6+   $& 0.987Q�6=   � 5�      $% 	#FF938888��6+   $& 0.637Q�6=   5�      .+�5�      �� -!   5        $ ListViewMenu��5�       ���	#FF5C99D6$��Disabled=�6M   ���	#FF42274F$��Right=�6�   5�      5�      5�      5�      5�      5�      