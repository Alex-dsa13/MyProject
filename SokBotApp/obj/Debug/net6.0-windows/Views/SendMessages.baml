   M S B A M L   `   `   `  ????D  @SokBotApp, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:SokBotApp.ViewsSokBotApp.Views  5      "    SokBotApp.Views.SendMessages   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:SokBotApp.Views     5        N? Title$  SendMessages??5	      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??0.15* ?6   6-   ?? 5      $??* ?6   6)    ? ColumnDefinitions 5   
   ?? 5      $
??0.4* ?6   6.   ?? 5      $
??0.4* ?6   6.   .+?5   
   ?? $??0??6   $??0??6%   $
??Left=?62   $??	50,20,0,0q?6M   .+?5      ?? -   5         ??Name$ 
backButton??5   *   ???#62A4EF$	??150??6>   $??30??6J   $??0,0,0,0q?6o    ? Cursor$
 Hand??6?   
??????????#62A4EF.??6?   
Назад5      5      ?? 5   
   $??0??6   $??1??6%   $??	50,00,0,0q?62   .+?5      ?? -   5         ??Name$ membersCount??5      $??18(?6*   $??Regular"?68   6O   ?? 5      $??18(?6   $??Regular"?6"   $??0,20,0,0q?67   .??6I   B@Введите текст рассылки в поле ниже.6n   ?? 5      -   5         ??Name$ messageTextBox??5   _   ???#F2F3F5 ?? AcceptsReturn$
 True??6+   $	??300??6@   $??0,10,0,0q?6M    ?? 	MaxLength$
 1000??6w   $??16(?6?   $??Regular"?6?   $??10,10,10,10q?6?   	 ?? TextWrapping$
	 Wrap=?6?   6?   ?? 5      -   5        $ 
sendButton??5   E   ???#62A4EF$
??Left=?6*   $	??150??6Y   $??30??6e   $??0,50,0,0q?6?   $
 Hand??6?   
??????????#62A4EF.??6?   Отправить6?   5       ?? 5"   
   $??1??6   $??1??6%   $??	50,00,0,0q?62   .+?5#      ?? -   5        $ mailInfo??5#      $??18(?6&   $??Regular"?64   .??6I   @>Информация об отправке сообщений:6l   ?? 5$      -   5        
 ??Name$
 messageConsole??5$   ,    ?? 
IsReadOnly$
 True??6   $	??400??6D   $??0,0,50,0q?6Q   $??16(?6c   $??Regular"?6q   $??10,10,10,10q?6?   
???????5&      ?? 5'      -   5        $
 	finalInfo??5'   ,   $
 True??6   $??50??6?   $??	0,30,50,0q?6K   $??18(?6^   $??SemiBold"?6l   $??10,10,10,10q?6?   
???????6?   5(      5)      5*      