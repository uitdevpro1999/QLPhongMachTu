   M S B A M L   `   `   `  ����?  ;QLPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLPMQLPM  5   	       QLPM.danhsachbenh   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   localclr-namespace:QLPM  5   	     � Title$  Danh sách loại bệnh��5	   	   $	��450��6%   $	��800��62   
������� � Icon$! images/icons/cardiogram.ico��6X   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$
 grid��5      $
��Left=�6!   $	��194��6<   $��
10,216,0,0q�6I   $	��Top=�6]   $	��774��6u      AutoGenerateColumns .  
������� � ContextMenu 5      �� 5      .@�5      m� -   5        $��Sửa��5      6,   m� 5      -   5        $
��Xóa��5      6,   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã loại bệnh��6@      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *maBenh+6V     5      $ Tên loại bệnh��6A   $	 490 6X    6%   �� *	tenBenh+6X   5      �� 5   
       MaterialDesignTitleTextBlock#��[  6   $��161,86,496.6,304q�6J   Nhập từ khóa:5      �� 5   
   -   5        	 ��Name$	 mabenh��5      $
��Left=�6"   $��25��6=   $��
302,86,0,0q�6I   
 �� TextWrapping$

 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��114��6�   �� 5    
   -   5         . *MaterialDesignFloatingActionMiniDarkButton#��[ 5        � ToolTip$0 *MaterialDesignFloatingActionMiniDarkButton��6U   $��498,81,255.6,299q�6�   $
��Auto��6�   $
��Auto��6�   .��5!      �� $��images/icons/add-24.png��6   $��Uniform=�65   $��17��6G   $��17��6S   5"      �� 5#   
   -   5        #��[ 5#      $0 *MaterialDesignFloatingActionMiniDarkButton��6U   $��559,81,194.6,299q�6�   $
��Auto��6�   $
��Auto��6�   .��5$      �� $"��images/icons/arrow-84-24.png��6   $��Uniform=�6:   $��17��6L   $��17��6X   5%      �� 5&   
   -   5        #��[ 5&      $1 +MaterialDesignFloatingActionMiniLightButton��6U   $��439,81,314.6,299q�6�   $
��Auto��6�   $
��Auto��6�   .��5'      �� $#��images/icons/search-12-16.png��6   $��Uniform=�6;   $��17��6M   $��17��6Y   5(      5*      5+      