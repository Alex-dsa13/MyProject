   M S B A M L   `   `   `  ????D  @SokBotApp, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SokBotApp.ViewsSokBotApp.Views  5      %    SokBotApp.Views.EventStatistics   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:SokBotApp.Views     5        N? Title$  EventStatistics??5	      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??0.1* ?6   6,   ?? 5      $??0.15* ?6   6-   ?? 5      $
??0.3* ?6   6,   ?? 5      6    ? ColumnDefinitions 5   
   ?? 5      $??* ?6   6+   ?? 5      $??* ?6   6+   ?? 5      $??* ?6   6+   ?? 5      $??* ?6   6+   .+?5   
   ?? $??0??6   $??0??6%   $
??Left=?62    ?? Orientation$ 
Horizontal=?6M   .+?5      ?? -   5         ??Name$ 
backButton??5   *   ???#62A4EF$	??150??6>   $??30??6J   $??30,0,0,0q?6o    ? Cursor$
 Hand??6?   
??????????#62A4EF.??6?   
Назад6?   5      ?? 5   
   $??0??6   $??2??6%   .+?5      ?? $ Vertical=?6   .+?5       ?? $ 
Horizontal=?6   .+?5!      ?? $??18(?6   $
??Bold"?6*   $
??30 0q?6<   .??6J   " Всего участников:6]   ?? 5"      -   5         ??Name$ studentsCount??5"   P   $??18(?6"   $
??Bold"?60   $
??10 5q?6B    ?? 
IsReadOnly$
 True??6g   $??50??6y   
???????
???????$|?False??6?   6?   5#      ?? 5%      $ 
Horizontal=?6   .+?5&      ?? $??18(?6   $
??Bold"?6*   $
??30 0q?6<   .??6J   Всего команд:6Y   ?? 5'      -   5        $ 
teamsCount??5'   P   $??18(?6"   $
??Bold"?60   $
??10 5q?6B   $
 True??6d   $??50??6v   
???????
???????$|?False??6?   6?   5(      5+      5,      ?? 5.   
   -   5         ??Name$ 	teamsList??5.   2   $??3??6   $??0??6"   53      ?? 55   
   -   5        $ LinkToMembers??55   2   $??3??6   $??1??6"   57      ?? 59   
   $??3??6   $??2??6"   $??3??62   .+?5:      ?? -   5        $ stats??5:      $	??500??6)   $	??300??65   $??18(?6B   $??Regular"?6P   $??10,10,10,10q?6e   
???????
???????$
 True??6?   $|?False??6?   6?   5;      5=      5>      