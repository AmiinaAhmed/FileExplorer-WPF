   M S B A M L   `   `   `  ����J  FFileExplorerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FileExplorerWPFFileExplorerWPF  5   	   "    FileExplorerWPF.RenameWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:FileExplorerWPF     5   	   $��230.412��65   $��646.907��6F     � Title$  
Properties��5   	    � WindowStartupLocation$ CenterOwner=�6   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ txt_fileName��5      $��23��6(   $��	87,3,10,0q�64    �� TextWrapping$
 Wrap=�6G   $	��Top=�6\   $��1��6t   �� 5   
   -   5         ��Name$ 
btn_rename��5      $
��Save��6>   $��
65,11,0,-5q�6M   $
��Left=�6a   $��98��6|   $��32��6�   $	��Top=�6�   $��2��6�   �� 5   
   -   5         ��Name$ label��5      $��Name :��6   $
��Left=�60   $��9,1,0,0q�6K   $	��Top=�6\   $��49��6t   $��1��6   �� 5   
   -   5        $ txt_path��5   $   {�.  $��
87,10,10,0q�67   $
 Wrap=�6K   $	��Top=�6`   �� 5   
   -   5        $ 
label_Copy��5      $��Path   :��6$   $
��Left=�67   $��	10,10,0,0q�6R   $	��Top=�6e   $��49.624��6}   �� 5   
   -   5        $ 	btn_close��5      $��Close��6$   $��168.308,10.771,0,-6.01q�6L   $
��Left=�6l   $��98.684��6�   $	��Top=�6�   $��2��6�   �� 5   
   -   5        $ Extention_lbl��5      $��Extention :��6'   $
��Left=�6=   $��8,35,0,0q�6X   $	��Top=�6j   $��70��6�   �� 5   
   -   5        $ txt_Extention��5   $   {�.  $��
87,36,10,0q�6<   $
 Wrap=�6P   $	��Top=�6e   �� 5   
   -	   5        $ txt_Size��5      {�.  $��23��66   $��
87,29,10,0q�6B   $
 Wrap=�6V   $	��Top=�6k   $��1��6�   �� 5   
   -
   5        $ label_Copy1��5      $��Size :��6%   $
��Left=�66   $��9,28,0,0q�6Q   $	��Top=�6c   $��49��6{   $��1��6�   �� 5   
   -   5        $ txt_DateModified��5      {�.  $��23��6>   $��113,52,10,0q�6J   $
 Wrap=�6_   $	��Top=�6t   $��1��6�   �� 5   
   -   5        $ label_Copy2��5      $��Data Modified :��6%   $
��Left=�6?   $��9,50,0,0q�6Z   $	��Top=�6l   $��99��6�   $��1��6�   5      5      