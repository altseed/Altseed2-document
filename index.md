---
title: Altseed2
documentType: index
master: _titlemaster
---

>[!div id="budges"]
>NuGet: <a href="https://www.nuget.org/packages/Altseed2" target="_blank" rel="noopener noreferrer"><img src="https://img.shields.io/nuget/vpre/Altseed2?color=darkgreen&logo=nuget&label=%20&style=plastic)](https://www.nuget.org/packages/Altseed2"/></a>
>Engine:<a href="https://github.com/altseed/Altseed2-csharp" target="_blank" rel="noopener noreferrer"><img src="https://img.shields.io/github/commits-since/altseed/Altseed2-csharp/2.0.0?include_prereleases&logo=github&color=blue&style=plastic"/></a>
>Core:<a href="https://github.com/altseed/Altseed2" target="_blank" rel="noopener noreferrer"><img src="https://img.shields.io/github/milestones/progress/altseed/Altseed2/1?color=orange&logo=github&style=plastic"/></a>


## Altseed2とは

Altseed2 は画面描画・音・入力・衝突判定などの機能をまとめたゲーム用ライブラリです。
オブジェクト指向を用いた開発に適したインタフェースにより、複雑になりがちな機能を少ないコード量で実装することができます。
かつての Altseed と異なり、ノードシステムを採用しており、オブジェクトやオブジェクトが持つ機能の管理を、より柔軟かつ統一的に行うことができます。
その他にも、Altseed2 には初代 Altseed にはなかった機能がいくつか実装されています。

## ページ

- [チュートリアル](Tutorials/Chap0/index.md) : プログラミング初心者向けに、Altseed2 を使ってシューティングゲームを実装するコースを用意してあります。
- [機能解説](Manual/Engine/Engine.md) : Altseed2 の各機能についてサンプルコードと共に使い方の解説を学べます。
- [リファレンス](xref:Altseed2) : 各クラスのプロパティやメソッドについて詳細に確認することができます。


## 必要な環境
- Windows : 10 以降 (DirectX11 以上が必要)
- Mac : Mojave 以降
- Linux : 2.1 以降

## ライセンス
Altseed2 の開発者が書いたコードは MIT ライセンスですが、Altseed2 を利用したアプリケーションを配布する際には、Altseed2 が利用しているすべてのライブラリのライセンスについても記述する必要があります。
Altseed2 をダウンロードした際に含まれている `LICENSE` ファイルを、または GitHub 上の <a href="https://github.com/altseed/Altseed2/blob/master/LICENSE" target="_blank" rel="noopener noreferrer">`LICENSE`</a> ファイルをダウンロードして、アプリケーション配布時に含めるようにしてください。

## サポート
- <a href="https://github.com/altseed/Altseed2" target="_blank" rel="noopener noreferrer">GitHub</a>
- <a href="https://twitter.com/altseed" target="_blank" rel="noopener noreferrer">Twitter</a>
- <a href="https://altseed.herokuapp.com/" target="_blank" rel="noopener noreferrer">Slack</a>

## Altseed2 でできること

### 例 : [オーディオビジュアライザ](Manual/Sound/Sound.md)
Altseed2 では再生中の音声についてスペクトル解析を行うことができます。
これを使用して、音楽に合わせて動くオブジェクトを実装することができます。

<video width="320" height="240" autoplay muted="true" loop="true" preload poster="Images/Spectrum.png">
  <source src="Images/Spectrum.mp4" type="video/mp4">
  <source src="Images/Spectrum.webm" type="video/webm">
  <img src="Images/Spectrum.png">
</video>

<!--[!code-csharp[Main](Src/Samples/AudioVisualizerDemonstration/AudioVisualizerDemonstration.cs)]-->

### 例 : [衝突判定](Manual/Physics/Collision.md)
Altseed2 ではオブジェクト同士の衝突判定を行うことができます。
衝突時の処理をメソッドとして簡単に記述することができます。

<video width="320" height="240" autoplay muted="true" loop="true" preload poster="Images/Collision.png">
  <source src="Images/Collision.mp4" type="video/mp4">
  <source src="Images/Collision.webm" type="video/webm">
  <img src="Images/Collision.png">
</video>

<!--[!code-csharp[Main](Src/Samples/CollisionDemonstration/CollisionDemonstration.cs)]-->

### 例 : [ジョイスティック](Manual/Input/Joystick.md)
Altseed2 では、SDL_GameControllerDBによって記述されているコントローラ（100~200種類ほど）に対して、ゲームパッドのボタンの種類（[`JoystickButton`](xref:Altseed2.JoystickButton)）によってその入力を取得することができます。
これにより、単一のコードで100種類以上のゲームパッドに対応することができます。
非対応のコントローラーでも、ボタンのインデックスを利用して入力を取得可能です。

### 例 : [カメラ](Manual/Graphics/Camera.md)
Altseed2 では、カメラ機能を利用することで特定の範囲だけを切り取って描画することができます。

### 例 : [ポストエフェクト](Manual/Graphics/PostEffect.md)
Altseed2 では、ポストエフェクト機能を利用して描画結果に加工を加えられます。
標準ではグレースケール、セピア、ガウスぼかし、ライトブルームを利用できます。
シェーダーを記述して、独自のポストエフェクトを作成することもできます。

### 例 : [マテリアル](Manual/Graphics/Material.md)
Altseed2 では、HLSL を利用してシェーダーを記述できます。
シェーダーはプラットフォームごとに自動で変換されるため、単一のシェーダがすべてのプラットフォームで動作します。

### 例 : [フォントファイルの画像化](Manual/Graphics/Text.md)
Altseed2 では、フォントファイルを事前に画像ファイル（静的フォントファイル）に変換して読み込むことができます。
ライセンスによってフォントファイルそのものを配布できない場合でも、画像に変換することで利用できる場合があります。（ライセンスはフォントごとに異なるので、使用しているフォントのライセンスをよく確認してください）

また、Altseed2 では MSDF を利用しているため、描画したいサイズごとにフォントを読み込む必要がなくなりました。

### 例 : [ファイルパッケージ](Manual/File/Package.md)
Altseed2 では、画像ファイルや音声ファイルを入れたリソースフォルダを、暗号化したパッケージファイルに変換することができます。
ゲームファイルを配布する際には暗号化したリソースを利用することで、画像や音声が意図しない使われ方をすることを防ぐことができます。

### 例 : [プロファイリング](Manual/Profiler/Profiler.md)
プロファイラ機能を利用して、特定の範囲の処理の実行に掛かる時間を測定する事ができます。

### 例 : [.NETツール](Manual/CLITool.md)
Altseed2 では、リソースフォルダやフォントファイルの変換するためのツールをNuGet経由でインストール可能になりました。

## Altseed2 For Rust について

現在、Rust で使用できる Altseed2 を鋭意開発中です。
