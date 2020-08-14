# Altseed2 Document

[Altseed2](https://github.com/altseed/altseed2-csharp)のドキュメント

## Issue
issueは[Altseed2/issues](https://github.com/altseed/Altseed2/issues)に作成してください。


# 生成に必要なもの

- Visual Studio
  - ほかのC#コンパイラでいけるかは不明
  - Homebrew で入れた Mono はダメとある。
- [DocFX](https://github.com/dotnet/docfx)
  - `choco install docfx` するか Release からバイナリを落として解凍し、パスを通す

# 生成

`docfx --serve` 

# 書き方

- 基本的には Markdown。シンタックスについては[ココ](https://github.github.com/gfm/)を参照
- 一部 DocFX 独自拡張があるのでそれについては[ココ](https://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html?tabs=tabid-1%2Ctabid-a)
  - ソースコード埋め込みとNOTEくらいか

## 構造について
```
- index.md ・・・ トップページ
- References　・・・ リファレンス（自動生成なので触らない）
- Manual
  - *.md ・・・ 各機能に関する文書（書く）
  - *.cs ・・・ ~~各機能に埋め込むサンプルコード（書く）~~ サンプルコードは Engineへ
  - *.png ・・・ 埋め込む画像（撮るか描く）
  - toc.yml ・・・ サンプルの目次（書く）
- Tutorials
  - *.md ・・・ チュートリアルに関する文書（書く）
  - ~~*.cs ・・・ チュートリアルに埋め込むサンプルコード（書く）~~
  - *.png ・・・ チュートリアルに埋め込む画像（撮るか描く）
  - toc.yml ・・・ チュートリアルの目次（書く）
- Site ・・・ 出力先
```

- toc.yml は新しいファイルを生成したら手動で追記する必要あり（目次に載せないなら書かない）
- SamplesとTutorials以下に置いたpng画像はコピーされる
