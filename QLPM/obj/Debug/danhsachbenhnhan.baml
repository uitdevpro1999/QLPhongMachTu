   M S B A M L   `   `   `  ����?  ;QLPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLPMQLPM  5   	       QLPM.danhsachbenhnhan   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:QLPM     5   	     � Title$  Danh sách bệnh nhân��5   	   $	��450��6%   $	��800��62   
������� � Icon$! images/icons/cardiogram.ico��6X   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$
 grid��5
      $
��Left=�6!   $	��230��6<   $��
10,180,0,0q�6I   $	��Top=�6]   $	��774��6u   
�������   AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 STT��6=      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6J   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *sTT+6J     5      $ 	Họ Tên��6?   $	 180 6O    6%   �� *tenBN+6O     5      $ Ngày Khám��6B   $	 180 6U    6%   �� *
NgayKham+6U     5      $ Loại Bệnh��6A   $	 180 6T    6%   �� *	tenBenh+6T     5      $ Triệu Chứng��6D   $	 180 6Y    6%   �� *
TrieuChung+6Y   5      �� 5   
   $
��Left=�6   $��
190,70,0,0q�6/   
�����@�$��35(�6Z   $��Medium"�6h   $
��Wrap=�6|   $��DANH SÁCH BỆNH NHÂN��6�   $	��Top=�6�   5      5      