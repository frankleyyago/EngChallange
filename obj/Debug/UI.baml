   M S B A M L   `   `   `  ����G  CEngChallange, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EngChallangeEngChallange  5          EngChallange.UI   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:EngChallange     5        � Title$  Parameter Scanner��5   	   $	��300��5      $	��300��6    � WindowStartupLocation$ CenterScreen=�6'    � 
ResizeMode$ NoResize=�6L   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $J��Dpack://application:,,,/EngChallange;component//Resources/IconUI2.ico��6   $��60��6k   $��60��6v   �� 5   
   $��1��6   $��Paramater Name��6   $��Center=�66   �� 5   
   -   5         ��Name$ ParamaterNameTextBox��5      $��1��60   $��
120,0,10,0q�6=   $��Center=�6Q   �� 5   
   $��2��6   $��Paramater Value��6   $��Center=�67   �� 5   
   -   5        $ ParameterValueTextBox��5      $��2��61   $��
120,0,10,0q�6>   $��Center=�6R   �� 5   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� -   5         ��Name$ 
btnIsolate��5      $��Isolate in View��6)   $��
0,20,10,20q�6C   $��5q�6W   $	��100��6c   $��30��6o   
�������6�   �� 5      -   5        $ 	btnSelect��5      $��Select��6(   $��
40,20,0,20q�69   $��5q�6M   $	��100��6Y   $��30��6e   
�������6�   5      5      5      