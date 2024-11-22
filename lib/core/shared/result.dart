class Result<I, E> {
  final I? _data;
  final E? _error;

  Result._(this._data, this._error);

  static Result<I, E> success<I, E>(I data) => Result._(data, null);
  static Result<I, E> failure<I, E>(E error) => Result._(null, error);

  bool get isSuccess => _data != null;
  bool get isFailure => _error != null;

  I? get dataOrNull => _data;
  E? get errorOrNull => _error;

  Result<I, E> onSuccess(Function(I value) action) {
    if(isSuccess) {
      action(_data as I);
    }

    return this;
  }

  Result<I, E> onError(Function(E value) action) {
    if(isFailure) {
      action(_error as E);
    }

    return this;
  }
}