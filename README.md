# FontChoices
![アプリスクリーンショット](https://github.com/TN8001/FontChoices/blob/master/AppImage.png)
## 概要
WPF用FontPicker&FontDialog
## 特徴
信じられないですがWPFにはFontDialogがありません。  
NuGetをよく調べれば良いものがあるかもしれませんが、自分用に作りました。  
即時反映できるFontPickerがメインです。FontDialogはおまけです（モーダルは好みでないので私は使っていません）
## 使い方
FontChoicesDemoプロジェクトを参照のこと。
## ライセンス
[MIT](https://github.com/TN8001/FontChoices/blob/master/LICENSE)
## 注意事項
* 一切責任は持ちません
* Style・Weight・StretchはFontPickerへ設定はできません 取得のみです
* UpDownだけのためにExtended WPF Toolkitを参照してしまっています。（UpDown位なら自分で作ってもいいんですが どうせColorPicker等も使うことが多いので。。。ColorPickerは自作する気はしない）