# エンジン

[Engine](xref:Altseed2.Engine) は Altseed2 の基本的な機能を提供します。初期化・終了をはじめとする、Altseed2 のほとんどの機能は [Engine](xref:Altseed2.Engine) を通して使用します。

## エンジンでできること

[Engine](xref:Altseed2.Engine) は次の機能を提供します。

* Altseed2 の初期化・更新処理・終了処理
* [Node](xref:Altseed2.Node) の登録・削除・更新
* 各モジュール
  * [Sound](xref:Altseed2.SoundMixer)：サウンドの再生


## 基本的な実行手順

Altseed2 を使用するプログラムの基本構造は次のようになります。

[!code-csharp[Main](../../Src/Samples/Engine/Empty.cs)]

> [!CAUTION]
> [Initialize](xref:Altseed2.Engine.Initialize(System.String,System.Int32,System.Int32,Altseed2.Configuration))、[Terminate](xref:Altseed2.Engine.Terminate)、[DoEvents](xref:Altseed2.Engine.DoEvents)、[Update](xref:Altseed2.Engine.Update)のメソッドはこのサンプルのように必ず使用します。  
> また Altseed2 のすべての機能は [Initialize](xref:Altseed2.Engine.Initialize(System.String,System.Int32,System.Int32,Altseed2.Configuration)) してから [Terminate](xref:Altseed2.Engine.Terminate) するまでの間に実行されるようにしてください。[Initialize](xref:Altseed2.Engine.Initialize(System.String,System.Int32,System.Int32,Altseed2.Configuration)) の前や、[Terminate](xref:Altseed2.Engine.Terminate) の後で、Altseed2 の機能を使用すると予期せぬエラーが発生することがあります。

## [Configuration](xref:Altseed2.Configuration) について

Altseed2 の一部機能は、初期化時に [Initialize](xref:Altseed2.Engine.Initialize(System.String,System.Int32,System.Int32,Altseed2.Configuration)) の引数として渡す　[Configuration](xref:Altseed2.Configuration) を用いて設定します。 設定項目の詳細については [Configuration](xref:Altseed2.Configuration) のリファレンス をご覧ください。

## ポーズ（一時停止）

ゲームのプレイ中に、ゲームを一時中断して設定を変更したり休憩したりすることがあります。このような機能を実装するときは、各 [Node](xref:Altseed2.Node) の毎フレームの更新を停止する必要があります。しかし、一部のメニューやアニメーションなどは停止せず、更新し続ける必要があります。 
Altseed2 では、ゲームの一時停止は [Pause](xref:Altseed2.Engine.Pause(Altseed2.Node))メソッドで、ゲームの再開は [Resume](xref:Altseed2.Engine.Resume) メソッドによって実現できます。 なお、[Pause](xref:Altseed2.Engine.Pause(Altseed2.Node))メソッドの引数にメニュー画面などの[Node](xref:Altseed2.Node)を渡すことにより、その [Node](xref:Altseed2.Node) を一時停止の対象から除外することができます。

> [!NOTE]
> 初代 Altseed では、ゲームのシーンにメニュー画面のレイヤーを追加したうえで、メニュー画面のレイヤー以外のすべてのレイヤーの `IsUpdated` プロパティを `false` にすることで実現していました。Altseed2 では上記のような方法でゲームのポーズ（一時停止）を実現します。

## フレームレート

Altseed2 は固定フレームレート、可変フレームレート両方に対応しています。初期値では可変フレームレートに設定されています。どちらの場合でも、1秒間の更新回数は [TargetFPS](xref:Altseed2.Engine.TargetFPS) で指定されている値に近づくように調整されます。[Node](xref:Altseed2.Node) の [OnUpdate](xref:Altseed2.Node.OnUpdate) メソッドの実行や描画処理などの更新処理は、毎秒およそこの値の回数実行されます。

<!-- TODO:残り書く -->

> [!CAUTION]
> ホ　ン　マ　か　？　？
