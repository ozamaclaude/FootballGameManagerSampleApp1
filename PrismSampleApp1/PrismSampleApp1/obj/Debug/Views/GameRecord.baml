   M S B A M L   `   `   `  ����  PrismSampleApp1&     PrismSampleApp1.Views.GameRecord   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Y UPrism.Unity.Wpf, Version=8.0.0.1909, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59S OPrism.Wpf, Version=8.0.0.1909, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  TrueX�5      $	��600��5      $	��700��6   .��5      � 
������� � ColumnDefinitions 5   
   �� 5	      $��10 �6   �� 5
      $��* �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��5 �6   �� 5      $��40 �6   �� 5      $��5 �6   �� 5      $��* �6   �� 5      $��2 �6   .+�5   
   � $��1��6   $��1��6    5      �� 5      $��30 �6#   �� 5      $	��300 �6#   �� 5      $��20 �6#   �� 5      $	��300 �6#   �� 5      $��30 �6#   .+�5      �� $��1��6   $��学年指定��6(   $��18��5      $��14(�6$   
�������$
��Left=�5       $��Center=�63   �� 5"      $��3��6   $��	50 5 30 5q�6'   $��16��6:    �� SelectedItem 5#      �� *SelectedGrade+ �� Mode$ TwoWay=�.@�5$      �� 6!   �� 5%      .��6   代表6#   �� 5&      .��6   ジュニア6%   �� 5'      .��6   
2年以下6%   �� 5(      .��6   
3年以下6%   �� 5)      .��6   66"   �� 5*      .��6   56"   �� 5+      .��6   46"   �� 5,      .��6   36"   �� 5-      .��6   26"   �� 5.      .��6   16"   �� 5/      .��6   幼児6#   50      51      �� 52   
   $��1��6   $��2��6$   $��	10 0 10 0q�61   � 56   
   $��1��6   $��3��6    57      �� 58      $��10 �6#   �� 59      $��* �6#   �� 5:      $��10 �6#    5<      �� 5=      $��5 �6    �� 5>      $��30 �6    �� 5?      $��5 �6    �� 5@      $��40 �6    �� 5A      $��5 �6    �� 5B      $	��180 �6    �� 5C      $��5 �6    �� 5D      $��90 �6    �� 5E      $��5 �6    �� 5F      $	��100 �6    �� 5G      $��5 �6    �� 5H      $��50 �6    �� 5I      $��5 �6    .+�5K      �� $��1��6   $��1��6)    �� Orientation$ 
Horizontal=�66   .+�5L      �� $��	試合日��6   $��16(�6'   
�������$��0 0 10 0q�6H   �� 5M      $��16��6   $	��120��6'   $	��Top=�63   $��0 0 10 0q�6K   ��5N      �� *
GameDate+$ TwoWay=��� 5O      $��対戦相手��6   $��16(�6(   
�������$��0 0 10 0q�6J   �� 5P      $��16��6   $	��120��6'   $	��Top=�63   $��0 0 10 0q�6K   ��5Q      �� *
Opponent+$ TwoWay=��� 5R      $��場所��6   $��16(�6&   
�������$��0 0 10 0q�6H   �� 5S      $��16��6   $	��120��6'   $	��Top=�63   ��5T      �� *Place+$ TwoWay=�5U      �� 5W      $��1��6   $��3��6)   $ 
Horizontal=�66   $��Center=�5X      .+�5Y      �� 
���#�k�$��30��64   $��0 0 10 0q�6@   .+�5Z      �� -   5        $��CurrentTime��5[       $��20��5Z       $	��170��6,    �� TextAlignment$ Right=�5\       $��Center=�5]       $��18(�5^       
���#�k�
�������5_       5`      �� 5a      $��30��6   $��70��6%   
�������$��12(�5b      
��� � �$��0 0 10 0q�5e      ��5c      �� *
GameStatus+��5d      �� *MeasureTimeCommand+5e      �� 5h      $��30��6   $��20��6(   $ Center=�5j      
����  �$��18(�5l      
�������$��0 0 0 0q�6=   ��5i      �� *Total+5l   =   �� 5m      $��30��6   $��20��6(   $��-��63   $ Center=�5n      
����  �$��14(�5p      
�������$��0 0 0 0q�6=   �� 5q      $��30��6   $��20��6(   $ Center=�5r      
����  �$��18(�5t      
�������$��0 0 10 0q�6=   ��5q   3   �� *OpponentTotal+5t   =   �� 5w      $��30��6   $��70��6%   
�������$��12(�5x      
����i��$��相手の得点��5y      $��0 0 10 0q�5{      ��5z      �� *OpponentAddScoreCommand+5{      �� 5|      $��16��6   $��60��6(   $��開始時刻��64   $��14(�5}      
�������$��0 0 5 0q�5~   /   �� 5      $��16��6   $��60��6(   $��14(�5�      
�������$��0 0 5 0q�5�   /   ��5�      �� *	StartTime+5�   /   �� 5�      $��16��6   $��60��6(   $��終了時刻��64   $��14(�5�      
�������$��0 0 5 0q�5�   /   �� 5�      $��16��6   $��60��6(   $��14(�5�      
�������$��0 0 10 0q�5�   /   ��5�      �� *	EndTime+5�   /   5�      �� 5�      $��1��6   $��5��6)   $ Vertical=�66   .+�5�      �� $��メンバー��6   $��14(�6(   
�������$��16��5�      $��Center=�6(   &   System.Windows.Controls.DataGrid  5�      $	��200��5�      $	��600��6(   $��10 10 10 10 q�64      AutoGenerateColumns .     CanUserAddRows .  ��5�      �� *PlayersGameData+$ TwoWay=� 5�      �� *CurrentRowItem+	   Columns	 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn
   Header$
 名前��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
PlayerName+  5�      $
 	男／女��6-    6:   �� *Gender+  5�      $
 学年��6-    69   �� *Grade+  5�      $
 ポジション��6-    6<   �� *
Position+  5�      $
 得点��6-    69   �� *Score+4  .System.Windows.Controls.DataGridTemplateColumn  5�      $
 得点追加��61      CellTemplate 5�      �� 5�   "   .R�5�   &   �� 
����i��
�������$��50��5�   -   $��追加��5�   -   ��5�   -   �� *DataContext.GetPointCommand+ �� RelativeSource ��  �� AncestorType"  5�   #   5�        5�      $
 交代時刻��6-    6;   �� *ChangingTime+  5�      $
 交代��61    5�      �� 5�   "   .R�5�   &   �� $��交代��6-   ��5�   -   �� *!DataContext.ChangeMemberCommand+ �� "  5�   #   5�      5�      5�      �� 5�      $��1��6   $��7��6)   $ Vertical=�66   .+�5�      �� $��所感��6   $��14(�6&   
�������$��16��5�   /   $��Center=�5�      �� 5�      $��80��6   $	��600��6&   $��10 10 10 10 q�62   ��5�      �� *	Summary+$ TwoWay=�5�      �� 5�      $��1��6   $��9��6)   $ Vertical=�66   .+�5�      �� $��結果��6   $��14(�6&   
�������$��16��5�      $��Center=�6(     5�      $	��100��5�      $	��600��6$   $��10 10 10 10 q�60    .   .  ��5�      �� *GameResults+$ TwoWay=�	 5�        5�      $
 学年��6-    69   �� *TeamDivision+  5�      $
 日時��6-    69   �� *
GameDate+  5�      $
 場所��6-    69   �� *Place+  5�      $
 対戦相手��6-    6;   �� *OpponentTeam+  5�      $
 	前後半��6-    6:   �� *Half+  5�      $
 結果��6-    69   �� *Result+  5�      $
 詳細��61    5�      �� 5�   "   .R�5�   &   �� 
����  �
�������$��50��5�   -   $��詳細��5�   -   ��5�   -   �� *&$DataContext.GetPlayersDetailsCommand+ �� "  5�   #   5�        5�      $
 所感��6-    69   �� *	Summary+  5�      $
 開始時間��6-    6;   �� *	StartTime+  5�      $
 終了時間��6-    6;   �� *	EndTime+5�      5�      �� 5�      $��1��6   $��11��6)   $ 
Horizontal=�67   $��Right=�5�      .+�5�      �� $��35��6   $��60��6%   $��登録��60   
����  �
�������$��16(�5�      $��0 0 10 0q�6'   ��5�      �� *RegisterCommand+5�   '   �� 5�      $��35��6   $��60��6%   $��保存��60   
���  ��
�������$��16(�5�      ��5�      �� *SaveCommand+5�      5�      5�      5�      5�      