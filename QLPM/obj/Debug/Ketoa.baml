   M S B A M L   `   `   `  ����?  ;QLPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLPMQLPM  5   	       
QLPM.Ketoa   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   localclr-namespace:QLPM  5   	     � Title$  Kê toa��5	   	   $	��450��6   $	��800��6%    � Icon$! images/icons/cardiogram.ico��61   
�������.��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$
 grid��5      $
��Left=�6!   $	��186��6<   $��
10,224,0,0q�6I   $	��Top=�6]   $	��774��6u      AutoGenerateColumns .   � DataContext 6�   ��  �� ElementName$ maThuoc�� � ContextMenu 5      �� 5      .@�5      m� -   5        $
��Xóa��5      6F   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã Thuốc��6A   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 88 6S   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *	maThuoc+6S     5      $ Tên Thuốc��6B   $		 190 6U   
 6%   �� *
tenThuoc+6U     5      $ Đơn vị tính��6=   $		 100 6R   
 6%   �� *DVT+6R     5      $ Cách Dùng��6B   $		 150 6U   
 6%   �� *
CachDung+6U     5      $ 
Đơn Giá��6@   $		 100 6Q   
 6%   �� *Dongia+6Q     5      $ Số Lượng��6A   $	 90 6S   
 6%   �� *	soLuong+6S   5      �� 5   
   $��Mã Toa��6   $
��Left=�6!   $��136,106,0,0q�6<   $	��Top=�6Q   �� 5   
   -   5         ��Name$ matoa��5      $
��Left=�6!   $��23��6<   $��209,108,0,0q�6H    �� TextWrapping$
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��120��6�   �� 5   
   -   5        $ mapkb��5      $
��Left=�6!   $��23��6<   $��523,108,0,0q�6H   $
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��120��6�   �� 5   
   $��Mã Phiếu Khám Bệnh��6   $
��Left=�6-   $��378,106,0,0q�6H   $	��Top=�6]   �� 5    
   $��Thuốc:��6   $
��Left=�6!   $��207,171,0,0q�6<   $	��Top=�6Q   $��15(�6i   �� 5!   
   -   5         ��Name$ thuoc��5!      $
��Left=�6"   $	��Top=�6=   $	��120��6U   $��266,173,0,0q�6a   �� 5"   
   -   5        $��+��5"      $��15(�6   $
��Left=�6+   $	��Top=�6F   $��46��6^   $��497,171,0,0q�6i    J� RenderTransformOrigin$ 1.023,0.257&�6�   $��36��6�   �� 5#   
   -   5        $��Kê Thuốc��5#      $
��Left=�6$   $��34��6?   $��
306,32,0,0q�6K   $	��Top=�6_   $	��169��6w   6�   �� 5$   
   -   5        $ soluong��5$      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Số lượng��6#    %  !MaterialDesignFloatingHintTextBox#��[  6M   $
��Left=�6�   $��47��6�   $��406,154,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $��69��6�   $ -0.253,-1.995&�6  5&      5'      