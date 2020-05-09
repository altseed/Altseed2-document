# 6章 : 当たり判定の機能を使ってみよう

5章では敵機と敵弾の作成までを行いました。しかしこのままでは当たり判定がないただのオブジェクトになってしまいます。   
本章では敵機と敵弾に当たり判定をつけていきます。   

## 当たり判定仕組み

「当たり判定」とは読んで字の如く、オブジェクト同士が当たっているかどうか判定するものです。当たり判定の実装方法には色々な手法が考えられますが、今回は簡単のために「円同士の当たり判定をピクセル単位で取る」という方法を扱います。

例えば下のような２つの円のオブジェクトを考え、２つの円の中心座標を考えてみましょう。２つの円の半径をa, bとおき、２つの円のx座標の差をd、y座標の差をeとおくと、中学校で習うような「三平方の定理」よりd²+e²<(a+b)²ならば２つの円は「ぶつかっている」ということになりますね。   

![当たり判定](06_collision.png)  

## 当たり判定実装
当たり判定の仕組みは上で説明したとおりですが、自分で一から実装するのは面倒なのでAltseed2ではこの当たり判定をまとめたクラスである`CircleCollider`が用意されています。  

早速この`CircleCollider`を使って当たり判定を実装していきましょう。  

今回は自機、自弾、敵機、敵弾の4つに当たり判定をつけるので基底クラスとして`CollidableObject`クラスを用意してそれを継承していくような実装にします。  
継承については以下を参照してください。  

[C# によるプログラミング入門 : 継承](https://ufcpp.net/study/csharp/oo_inherit.html)

`CollidableObject`のコードは以下のようになります。 

[!code-csharp[Main](CollidableObject.cs)]

これまで`SpriteNode`を継承していたため、`CollidableObject`でも`SpriteNode`を継承しています。  
また、`Enemy`クラスと`Bullet`クラスに定義していた`RemoveMyselfIfOutOfWindow`関数ですが同じ処理が二か所にあって冗長です。基本的に同じ処理は一か所にまとめた方が良いのでそれぞれの親クラスになる`CollidableObject`でこの関数を定義することにします。

変数とコンストラクタを解説していきます。
```C#
// コライダのコレクション
public static HashSet<CollidableObject> objects = new HashSet<CollidableObject>();

// コライダ
protected CircleCollider collider = new CircleCollider();

// OnUpdate内で衝突判定を調査するかどうか
protected bool doSurvey;

// 所属するメインノードへの参照
public MainNode mainNode;

// コンストラクタ
public CollidableObject(MainNode mainNode, Vector2F position)
{
    // メインノードへの参照を設定
    this.mainNode = mainNode;

    // コライダの座標を設定
    collider.Position = position;

    // 座標を設定
    Position = position;
}
```
  
それぞれのコライダとの当たり判定をとるためにコライダのコレクションを保存しておく必要があります。コライダオブジェクトは変数`objects`に保存します。  
この変数`objects`の宣言には`static`というキーワードが使われています。これは静的メンバーと呼ばれるもので、すべてのインスタンスから共有されるような変数を宣言できます。詳しい説明は以下のリンク先を参照してください。  

[C# によるプログラミング入門 : 静的メンバー](https://ufcpp.net/study/csharp/oo_static.html)  

変数`collider`はコライダの本体で、先ほど言ったようにAltseed2で用意された`CircleCollider`を使用します。
`doSurvey`と`mainNode`はコメントにある通りです。  
コンストラクタの`collider.Position = position`はコライダの位置設定で`Position = position`は本体の描画されているオブジェクトの位置設定であることに注意してください。  

次に`OnUpdate`です。  
```C#
// フレーム毎に実行
protected override void OnUpdate()
{
    // フラグが成立時に衝突判定を実行
    if (doSurvey)
    {
        Survey();
    }

    // コライダの座標を更新
    collider.Position = Position;
}
```
先ほど定義した`doSurvey`のフラグが`true`の場合後述する`Survey`関数が呼ばれて当たり判定が開始します。  
オブジェクトが動いてもコライダの位置は変わらないのでコライダとオブジェクトの位置と同期させるために`collider.Position = Position;`としています。  

さらに`OnAdded`関数と`OnRemoved`関数があると思います。こちらはエンジンにオブジェクトが追加されたタイミングと消去されたタイミングで呼ばれます。この時変数`objects`に追加と削除をしてエンジンに追加されているオブジェクトのみをコレクションに残しておきます。

Survey関数です。
```C#
// 衝突判定を調査する
private void Survey()
{
    // objects内の全オブジェクトを検索し，衝突が確認されたオブジェクト間でCollideWithを実行
    foreach (var obj in objects)
        if (collider.GetIsCollidedWith(obj.collider))
            CollideWith(obj);
}
```

コライダ間の衝突は`GetIsCollidedWith`関数で取ることができます。この関数は衝突している場合`true`を返すのでif文で衝突した場合に`CollideWith`が呼ばれます。`CollideWith`には衝突した場合の処理を書いていきます。

ここで、`foreach`とは`for`文の拡張で、

```cs
foreach (var obj in objects)
```

というのは、 「 `objects` の要素をとりだして、 `obj` と名前を付ける」 ことを`objects` の全要素について行ってくれます。  
今回は`foreach`文を使って`objects`から取り出した`CollidableObject`である`obj`のコライダ`obj.collider`と自身のコライダ`collider`の間での当たり判定を取っています。  
また、`var`というキーワードがあります。これは**型推論**と呼ばれるもので、名前の通り変数の宣言の際に型を推論してくれるというものです。なので上の`foreach`文は  

```C#
foreach (CollidableObject obj in objects)
    if (collider.GetIsCollidedWith(obj.collider))
        CollideWith(obj);
```
このようにしても大丈夫です。ただ、`var`を使ったほうが記述が短くて楽です。  

`foreach`と`var`についての詳しい解説を以下に載せておきます。  

[C# によるプログラミング入門 : foreach](https://ufcpp.net/study/csharp/sp_foreach.html)  
[C# によるプログラミング入門 : 型推論](https://ufcpp.net/study/csharp/sp3_inference.html)


`CollideWith`関数では衝突時の処理を書いていきます。

```C#
// 衝突時に実行
private void CollideWith(CollidableObject obj)
{
    // nullだったら終了
    if (obj == null)
    {
        return;
    }

    // 衝突対象がSurveyを実行しないオブジェクトだった場合，相手のOnCollisionも実行
    if (!obj.doSurvey)
    {
        obj.OnCollision(this);
    }

    // 自身のOnCollisiionを実行
    OnCollision(obj);
}
```
ここで，`Survey`を実行しないオブジェクト(=`doSurvey`が`false`)に対して`OnCollision`を呼び出しています。
何故，全ての`CollidableObject`に対して`Survey`を実行させず，`doSurvey`のような面倒な処理を挟むのかというのが気になるかと思います。
後々説明しますが，`doSurvey`フラグは自機や敵では`true`，自機弾や敵弾では`false`にします。
もし仮に全ての`CollidableObject`にて`Survey`を走らせるとなると，衝突判定が計算される回数は`objects`に登録されている`CollidableObject`の2乗に相当します。
弾というオブジェクトは，自機や敵の個数に比べて大量に画面上に出現する機会が多いです。その為，弾幕シューティングを作ったときなどは処理が重くなることがあります。
それを避けるために`doSurvey`というフラグを用いて`Survey`を実行する回数を最小限に留める事が出来ます。
プログラミングを行う際はこのようにパフォーマンスを意識するという事も大事です(最初のうちは動くこと重視，慣れてきたら意識すると良いです)。

オブジェクトにより当たった時の処理は異なるので継承先で`OnCollision`関数をオーバーライドさせて処理を継承先に委託するようにしています。  
`OnCollision`関数にあるキーワード`virtual`は仮想メソッドと呼ばれるものでこれをつけることで継承先で関数のオーバーライドができます。  

[C# によるプログラミング入門 : 多態性](https://ufcpp.net/study/csharp/oo_polymorphism.html?key=virtual_method#virtual_method)


```C#
// 衝突時に実行される内容をオーバーライドして設定できる
protected virtual void OnCollision(CollidableObject obj)
{

}
```

## 当たり判定を持つクラスへの切り替え
ざっとですが基本的なコライダの使い方を解説しました。  
次は継承先での処理を作っていきましょう。  

まずは各クラスを`CollidableObject`から継承させるようにします。  
`Player` クラス

```diff
-   public class Player : SpriteNode
+   public class Player : CollidableObject
```

`Enemy` クラス

```diff
-    public class Enemy : SpriteNode
+    public class Enemy : CollidableObject
```

`Bullet` クラス

```diff
-    class Bullet : SpriteNode
+    class Bullet : CollidableObject
```

さらにコンストラクタも書き換えていきます。
冒頭でも少し触れましたが`Enemy`クラスと`Bullet`クラスの`RemoveMyselfIfOutOfWindow`関数は親クラスである`CollidableObject`に移したのでついでに削除しましょう。

`Player` クラス

```diff
-       public Player(Vector2F position)
+       public Player(MainNode mainNode, Vector2F position) : base(mainNode, position)
        {
+           // 衝突判定を行うように設定
+           doSurvey = true;

            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Player.png");

            // 中心座標を設定
            CenterPosition = Texture.Size / 2;

+           // コライダの半径を設定
+           collider.Radius = Texture.Size.Y / 2;
        }
```

`Enemy` クラス

```diff
-       public Enemy(Player player, Vector2F position)
+       public Enemy(Player player, Vector2F position) : base(player.mainNode, position)
        {
+           // 衝突判定を行うように設定
+           doSurvey = true;

-           // 座標を設定
-           Position = position;

            // プレイヤーへの参照を設定
            this.player = player;
        }

-       private void RemoveMyselfIfOutOfWindow()
-       {
-           var halfSize = Texture.Size / 2;
-           if (Position.X < -halfSize.X
-               || Position.X > Engine.WindowSize.X + halfSize.X
-               || Position.Y < -halfSize.Y
-               || Position.Y > Engine.WindowSize.Y + halfSize.Y)
-           {
-               // 自身を削除
-               Parent?.RemoveChildNode(this);
-           }
-       }
```

`Bullet` クラス

```diff
-       public Bullet(Vector2F position, Vector2F velocity)
+       public Bullet(MainNode mainNpde, Vector2F position, Vector2F velocity) : base(mainNpde, position)
        {
+           // 衝突判定を行わないように設定
+           doSurvey = false;

-           // 座標を設定
-           Position = position;

            // 弾速を設定
            this.velocity = velocity;

            // 表示位置をプレイヤーや敵より奥に設定
            ZOrder--;
        }

-       private void RemoveMyselfIfOutOfWindow()
-       {
-           var halfSize = Texture.Size / 2;
-           if (Position.X < -halfSize.X
-               || Position.X > Engine.WindowSize.X + halfSize.X
-               || Position.Y < -halfSize.Y
-               || Position.Y > Engine.WindowSize.Y + halfSize.Y)
-           {
-               // 自身を削除
-               Parent?.RemoveChildNode(this);
-           }
-       }
```  

ここでコンストラクタの後ろに`base`というキーワードが出てきました。これは親クラスのコンストラクタ呼び出しという意味です。今回だと`ColliderObject`のコンストラクタを呼び出します。`ColliderObject`のコンストラクタでは`MainNode`と`position`が必要なため`base`の後の引数で受け渡します。`base`についての詳しい解説はこちらを参照してください。  

[C# によるプログラミング入門 : 継承](https://ufcpp.net/study/csharp/oo_inherit.html#base_ctor)  

また、`ColliderObject`のコンストラクタで座標を設定する処理があるので子クラスでは座標を設定するコードは消しています。  

`Bullet`の修正に併せて`EnemyBullet`と`PlayerBullet`のコードも修正していきましょう。

これらはコンストラクタの引数変更と半径を設定させるだけで大丈夫です

`EnemyBullet` クラス

```diff
+       public EnemyBullet(MainNode mainNode, Vector2F position, Vector2F velocity) : base(mainNode, position, velocity)
-       public EnemyBullet(Vector2F position, Vector2F velocity) : base(position, velocity)
        {
            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Bullet_Red.png");

            // 中心座標を設定
            CenterPosition = Texture.Size / 2;

+           // 半径を設定
+           collider.Radius = Texture.Size.X / 2;
        }
```

`PlayerBullet` クラス
```diff
+       public PlayerBullet(MainNode mainNode, Vector2F position) : base(mainNode, position, new Vector2F(10f, 0.0f))
-       public PlayerBullet(Vector2F position) : base(position, new Vector2F(10f, 0.0f))
        {
            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/Bullet_Blue.png");

            // 中心座標を設定
            CenterPosition = Texture.Size / 2;

+           // 半径を設定
+           collider.Radius = Texture.Size.X / 2;
        }
```

次に`Enemy`クラスの変更に併せてその派生クラスである`ChaseEnemy`クラスと`RadialShotEnemy`クラスと`StraightShotEnemy`クラスと`Meteor`クラスを書き換えていきます。先ほど`EnemyBullet`クラスの引数を変更したので`Shot`関数の`EnemyBullet`を生成するコードもついでに書き換えましょう。

`ChaseEnemy` クラス
```diff
        public ChaseEnemy(Player player, Vector2F position, float speed) : base(player, position)
        {
            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/UFO.png");

            // 中心座標を設定
            CenterPosition = Texture.Size / 2;

+           // 半径を設定
+           collider.Radius = Texture.Size.X / 2;

            // 移動速度を設定
            this.speed = speed;

            // 自身が倒された時に加算されるスコアを設定
            score = 10;
        }


```

`RadialShotEnemy` クラス
```diff
        public RadialShotEnemy(Player player, Vector2F position, int shotAmount) : base(player, position)
        {
            // 撃ち出すショットの個数を設定
            this.shotAmount = shotAmount;

            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/UFO.png");

            // 中心座標を設定
            CenterPosition = Texture.Size / 2;

+           // 半径を設定
+           collider.Radius = Texture.Size.X / 2;

            // スコアを設定
            score = 30;
        }

        // 弾を撃つ
        private void Shot(Vector2F velocity)
        {
            // 敵弾を画面に追加
+            Parent.AddChildNode(new EnemyBullet(mainNode, Position, velocity));
-            Parent.AddChildNode(new EnemyBullet(Position, velocity));
        }        
```

`StraightShotEnemy` クラス
```diff
        public StraightShotEnemy(Player player, Vector2F position) : base(player, position)
        {
            // テクスチャを読み込む
            Texture = Texture2D.LoadStrict("Resources/UFO.png");

            // 中心座標を設定
            CenterPosition = Texture.Size / 2;

+           // 半径を設定
+           collider.Radius = Texture.Size.X / 2;

            // 倒された時に加算されるスコアを設定
            score = 20;
        }

                // 弾を撃つ
        private void Shot(Vector2F velocity)
        {
            // 敵弾を画面に追加
+            Parent.AddChildNode(new EnemyBullet(mainNode, Position, velocity));
-            Parent.AddChildNode(new EnemyBullet(Position, velocity));
        }
```

`Meteor` クラス
```diff
        public Meteor(Player player, Vector2F position, Vector2F velocity) : base(player, position)
        {
            // 速度の設定
            this.velocity = velocity;

            // テクスチャの設定
            Texture = Texture2D.LoadStrict("Resources/Meteor.png");

            // 中心座標の設定
            CenterPosition = Texture.Size / 2;

+           // 半径の設定
+           collider.Radius = Texture.Size.X / 2;

            // スコアの設定
            score = 1;
        }
```

さらに`Player`クラスで`PlayerBullet`を使用していたのでこちらも修正が必要になります。  

`Player` クラスの `Shot` 関数
```diff
        // ショット
        private void Shot()
        {
            // Zキーでショットを放つ
            if (Engine.Keyboard.GetKeyState(Keys.Z) == ButtonState.Push)
            {
+               Parent.AddChildNode(new PlayerBullet(mainNode, Position + CenterPosition));
-               Parent.AddChildNode(new PlayerBullet(Position + CenterPosition));
            }
        }
```

最後に`MainNode`クラスを修正します。まず、`Player`クラスの呼び出しの変更が必要です。さらにもう一つ変更が必要です。もし`MainNode`が消去されてもコライダがコレクションに残っている場合、使われていないコライダがコレクションに保存され続けるとになります。この場合、ゲームのリトライなどを行うとリトライ前のコライダが残ってしまい、バグなどを引き起こす恐れがあるのでコライダの消去を行います。`HashSet`クラスの中身消去は`Clear`関数でできます。

`MainNode` クラス
```diff
        protected override void OnAdded()
        {
            // プレイヤーを設定
+            player = new Player(this, new Vector2F(100, 360));
-            player = new Player(new Vector2F(100, 360));
        }

+       // エンジンから削除されたときに実行
+       protected override void OnRemoved()
+       {
+           // 衝突判定を全てリセット
+           CollidableObject.objects.Clear();
+       }
```

これでひと段落と思いきや、衝突時の処理をまだ書いていないので衝突してもまだ何も起こりません。次にそれぞれのクラスで衝突した時の処理を書いていきたいところですが、先に衝突したときのエフェクトを作りましょう。

## Effectを作成するクラス
衝突したときに出すエフェクトである`DeathEffect`クラスを作ります。  
`DeathEffect`のコードは以下のようになります。  

[!code-csharp[Main](DeathEffect.cs)]  

どのように実装されているかというと以下のような画像の一部を表示して表示位置をずらしてあげることでアニメーションのような効果を出しています。  

![DeathEffect](Explosion.png)


コード中で使われている`Src`について説明します。今までは`Texture`に設定された画像全てを描画していましたが、今回は画像の一部だけを切り取って描画する必要があります。
そこで、`Src` を使用します。`Src`は`SpriteNode`クラスの持つフィールドで、`Src`に値を設定すると画像の中で指定された範囲のみが描画されるようになります。`Src`に値を設定する方法ですが、第一引数は表示したい範囲の左上の座標を、第二引数はその座標から表示する範囲を指定します

```C#
// 描画範囲を設定
Src = new RectF(pos, size);
```

設定する変数`size`と`pos`は`count`という毎フレーム1ずつ増える整数の変数を作って計算します。今回は2フレームごとに画像をずらすような式にしてあります。上に示した画像は爆破の画像が横に9枚並んでいるもので、2フレーム×9=18なので`count`が18になった場合`Parent.RemoveChildNode(this);`により自身を削除してエフェクトの再生を終了します。

```C#
// 表示されるテクスチャのサイズを取得
var size = new Vector2F(Texture.Size.X / 9, Texture.Size.Y);

// 表示されるテクスチャの左上の座標を計算する
var pos = new Vector2F(size.X * (count / 2 % 9), size.Y);

// 描画範囲を設定
Src = new RectF(pos, size);

// カウントを進める
count++;

// カウントが18以上で自身を削除
if (count >= 18)
{
    Parent.RemoveChildNode(this);
}
```

爆破のエフェクトが完成したので衝突時の処理を書いていきましょう。  

## OnCollideの実装
`CollidableObject`では衝突したときに`OnCollide`関数を呼び出すように実装しましたね。なので子クラスで`OnCollide`関数の中身を記述してあげればよいです。  
衝突時に処理するクラスは`Player`と`Enemy`と`PlayerBullet`と`EnemyBullet`の4クラスになります。  
これら4つの`OnCollide`関数を以下に載せます。  

`Player` クラス

```C#
// 衝突時に実行
protected override void OnCollision(CollidableObject obj)
{
    // 衝突対象が敵か敵の弾だったら
    if (obj is Enemy || obj is EnemyBullet)
    {
        // 自身を親から削除
        Parent.RemoveChildNode(this);
    }
}
```

`PlayerBullet` クラス
```C#
// 衝突時に実行
protected override void OnCollision(CollidableObject obj)
{
    // 衝突対象が敵だったら自身を削除
    if (obj is Enemy)
    {
        Parent?.RemoveChildNode(this);
    }
}
```

`Enemy` クラス
```C#
// 衝突時に実行
protected override void OnCollision(CollidableObject obj)
{
    // 衝突対象が自機弾だったら
    if (obj is PlayerBullet)
    {
        // スコアを加算
        mainNode.score += score;

        // 死亡時エフェクトを再生
        Parent.AddChildNode(new DeathEffect(Position));

        // 自身を削除
        Parent.RemoveChildNode(this);
    }
}
```

`EnemyBullet` クラス
```C#
// 衝突時に実行
protected override void OnCollision(CollidableObject obj)
{
    // 衝突対象がプレイヤーだったらBulletのOnCollisionを実行して削除
    if (obj is Player)
    {
        Parent?.RemoveChildNode(this);
    }
}
```  

ここで`is`というキーワードがありますね。これは**is演算子**と呼ばれるものです。この`is`というのは変数`obj`がどの型を継承しているのか判断するために使えます。一例ですが、`if (obj is Enemy)`と書けば、`obj`が`Enemy`クラスか、その派生クラスの時に処理をすることができます。  
余談ですが似たような機能に**as演算子**というものがあります。こちらは戻り値が`bool`ではなく型変換したものになります。
**is演算子**と**as演算子**について詳しく知りたい方は以下を参照してください。  

[C# によるプログラミング入門 : 多態性](https://ufcpp.net/study/csharp/oo_polymorphism.html#downcast)

## Meteorクラス改変
今、`Meteor`クラスの衝突処理は`Enemy`クラスの`OnCollide`が呼ばれるので、`Player`の弾に当たると消滅します。これで完成してもよいのですが、`Meteor`というからには岩石で硬いはずなので`Player`の弾ごとき3回くらいまでなら耐えると思います。 そのように改変しましょう。  

`Meteor` クラス
```diff
using Altseed;

namespace Tutorial
{
    // 隕石
    public class Meteor : Enemy
    {
        // フレーム毎の移動速度
        private Vector2F velocity;

+       // HP
+       private int HP = 3;

        // コンストラクタ、OnUpdate略

+        protected override void OnCollision(CollidableObject obj)
+        {
+           // 衝突したのが自機弾だったら
+           if (obj is PlayerBullet)
+           {
+               // HPを1減らす
+               HP--;
+               // HPが0になったらEnemyクラスのOnCollisionを呼び出して削除
+               if (HP == 0)
+               {
+                  base.OnCollision(obj);
+              }
+           }
+       }
+   }
}
```

HPというフィールドを追加して、プレイヤーの弾に当たる度にHPを1減らしていき、HPが0になったら消滅するというシンプルな処理です。  
このように`Enemy`クラスでオーバーライドした`OnCollision`をさらにオーバーライドすると親クラスの`OnCollision`は呼ばれなくなり、子クラスの処理に切り替わります。  

長い工程を経て衝突判定と衝突時の処理が完成しました。実行してみると敵に衝突したり、自弾が敵に衝突したときにエフェクトが出て画面から消えることが確認できると思います。  

## まとめ
今回は衝突判定をつけてみました。ようやくゲームらしさが増してきましたね。  
`Altseed2`では`CircleCollider`以外にも多角形のコライダである`PolygonCollier`クラスや四角形のコライダである`RectangleCollider`クラスがあります。もし、厳密さが必要な形のオブジェクトに衝突判定をつけたい場合はそちらを使ってみてください。  

次章では音を鳴らしてみます。