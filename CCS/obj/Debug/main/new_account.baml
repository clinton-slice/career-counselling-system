   M S B A M L   `   `   `  ����?  ;CCCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CCS.mainCCS.main  5          CCS.main.new_account   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:CCS.main     5      $	��378��5   7   $	��520��6C   .��5	      � ��5
   
   �� 5        �� ImageSource$  /CCCS;component/bg.jpg��6    j� Stretch$ UniformToFill=�6>   .+�5   
   �� -   5         ��Name$ image��5      $��46��6   $��161.667,14,159.333,0q�6+   $	��Top=�6I   $"��/CCCS;component/user/cgs.png��6a    J� OpacityMask 5      �� 5      $"  /CCCS;component/user/cgs.png��6   $ UniformToFill=�6H    �� Opacity$	 0.7Q�6`   5      �� 5   
   -   5         ��Name$ 	textBlock��5      $��33.334��6'   $��47.334,79,120.333,0q�67   $
��Wrap=�6T   $��Welcome!��6h   $	��Top=�6x   $��21.333(�6�   $��Segoe UI Semibold)�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#   	 � Offset$	 0Q�61   � 5      $ 	#FF90ABC6��6#   $	 1Q�65   5      5      �� 5   
   -   5        
 ��Name$
 button��5      $��Submit��6!   $��0,0,63,134.334q�62   ���	#FFCBE3F0$��30��6b   $��Bottom=�6n   $��Right=�6�   $��119.334��6�   
���������5      �� 5       �� Color$ 	#FF274564��6"   $	 0.9Q�64   5      �� 5   
   -   5        $ 
textBlock1��5      $��17.667��6(   $��34,184.333,32,0q�68   $
��Wrap=�6Q   $:��4To create an account, fill and submit the form below��6e   $	��Top=�6�   $��13.333(�6�   �� 5    
   -   5        $
 button2��5       $��106.333,0,84,47.167q�6"   ���	#FFCBE3F0$��30��6m   $��Bottom=�6y   ��5!      �� 5"      $ 	#FFFFFBFB��6"   $
 0.45Q�64   .��5%      ��  �� Orientation$ 
Horizontal=�6   .+�5&      �� $#��/CCCS;component/user/home.png��6   $��20.667��6?   $��23.042��6O   6`   �� 5'      $
��Home��6   6)   5(      5)      �� 5*   
   -   5        $ 
textBlock2��5*      $��27.999��6(   $��51,117.334,42,0q�68   $
��Wrap=�6Q   $.��(We are glad you chose to use this system��6e   $	��Top=�6�   $��14.667(�6�   $��Segoe UI Semibold)�6�   �� 5+   
   -   5         ��Name$ textBox��5+      $��105.333,0,56.667,221q�6#    �� TextWrapping$
 Wrap=�6A   $��26��6U   $��Bottom=�6a    �� 	MaxLength$ 60��6|   $��13.333(�6�   .��6�   ��5,      �� 5-      $ White��6"   $	 0.5Q�60   .��5.   "   5/      G� 50   
   -   5         G�Name$ passwordBox��50      $��26.666��6+   $��105.333,0,56.667,181.667q�6;   $��Bottom=�6]   $��13.333(�6x   ��51      �� 52      $ White��6"   $	 0.5Q�60   54      �� 55   
   -	   5         ��Name$ label��55      $��	Full Name��6   $
��Left=�63   $��26��6N   $��27.667,0,0,221q�6Z   $��Bottom=�6r   $��63.999��6�   �� 56   
   -
   5        $ 
label_Copy��56      $��Password��6$   $
��Left=�67   $��26��6R   $��27.667,0,0,182.333q�6^   $��Bottom=�6z   $��63.999��6�   �� 57   
   -   5        $ label1��57      $��Email��6    $
��Left=�60   $��28.667,236.333,0,0q�6K   $��53.333��6g   $��22.667��6v   $	��Top=�6�   �� 58   
   -   5        $ email��58      $�� ��6   $��105.333,236,56.667,257q�6*   $��Segoe UI Light)�6J   5:      5;      