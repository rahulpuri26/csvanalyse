   M S B A M L   `   `   `  ����  WpfApp1#    CodeLineCounterApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Code Line Counter��5   	   $	��600��6#   $	��900��60   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0 0 0 10q�6;   .+�5      �� -   5         ��Name$ RootFolderBox��5      $	��600��6-   $��0 0 10 0q�69   �� 5      -   5        $��	Browse...��5      $	��100��6D   5      �� 5   
   $ 
Horizontal=�6   $��1��6.   $��0 0 0 10q�6;   .+�5      �� $%��Include Extensions (.cs,.xaml):��6   $��Center=�6?   $��0 0 10 0q�6Z   �� 5      -   5        $ ExtensionsBox��5      $	��600��6-   5      �� 5   
   $ 
Horizontal=�6   $��2��6.   $��0 0 0 10q�6;   .+�5      �� $"��Exclude Paths (bin,obj,etc):��6   $��Center=�6<   $��0 0 10 0q�6W   �� 5      -   5        $ PathsBox��5      $	��600��6(   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ResultsGrid��5      $��3��6(      AutoGenerateColumns$
 True��65   $��0 0 0 10q�6P   �� 5   
   $ 
Horizontal=�6   $��4��6.   $
��Left=�6;   $��0 10 0 0q�6V   .+�5       �� -   5        $��Analyze��5       $	��100��6C   $��0 0 10 0q�6O   �� 5!      -   5        $��
Export CSV��5!      $	��100��6H   �� 5"      -   5         ��Name$ SummaryText��5"      $��20 0 0 0q�6-   $��Center=�6?   $
��Bold"�6Z   5#      5$      5%      