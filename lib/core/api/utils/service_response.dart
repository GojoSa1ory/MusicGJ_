class ServiceResponse<T> {
  final T? data;
  final String error;
  final bool isError;

  const ServiceResponse({
    required this.data,
    required this.error,
    required this.isError
  });
}